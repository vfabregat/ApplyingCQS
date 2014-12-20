
#region Usings
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using JustBlog.Core.Infrastructure;
using JustBlog.Core.Infrastructure.Data;
using JustBlog.Core.Infrastructure.Queries;
using JustBlog.Core.Objects;
using NHibernate;
using NHibernate.Cache;
using Ninject;
using Ninject.Extensions.Conventions;
using Ninject.Modules;
using Ninject.Web.Common;
#endregion

namespace JustBlog.Core
{
    /// <summary>
    /// Contains the bindings for db components.
    /// </summary>
    public class RepositoryModule : NinjectModule
    {
        public override void Load()
        {
            var connectionString = MsSqlConfiguration.MsSql2012.ConnectionString(c => c.FromConnectionStringWithKey("JustBlogDbConnString"));

            Bind<ISessionFactory>()
              .ToMethod(e => Fluently.Configure()
              .Database(connectionString)
              .Cache(c => c.UseQueryCache().ProviderClass<HashtableCacheProvider>())
              .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Post>())
              .BuildConfiguration()
              .BuildSessionFactory())
              .InSingletonScope();

            Bind<ISession>()
              .ToMethod((ctx) => ctx.Kernel.Get<ISessionFactory>().OpenSession())
              .InRequestScope();

            Bind<IDbContext>().To<DbContext>();
            Bind<IQueryProcessor>().To<DynamicQueryProcessor>();

            Kernel.Bind(c => c.FromThisAssembly()
                        .SelectAllClasses()
                        .InheritedFrom(typeof(IQueryHandler<,>))
                        .BindSingleInterface());

        }
    }
}
