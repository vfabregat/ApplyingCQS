
#region Usings
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using JustBlog.Core.Infrastructure;
using JustBlog.Core.Infrastructure.Queries;
using JustBlog.Core.Objects;
using JustBlog.Core.Objects.Dto;
using JustBlog.Core.Queries.Posts;
using NHibernate;
using NHibernate.Cache;
using Ninject;
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
                  //.ExposeConfiguration(cfg => new SchemaExport(cfg).Execute(true, true, false))
              .BuildConfiguration()
              .BuildSessionFactory())
              .InSingletonScope();

            Bind<ISession>()
              .ToMethod((ctx) => ctx.Kernel.Get<ISessionFactory>().OpenSession())
              .InRequestScope();

            Bind<IQueryProcessor>().To<DynamicQueryProcessor>();
            Bind<IQueryHandler<GetPagedPostsQuery, PagedResult<Post>>>().To<GetPagedPostsQueryHandler>();
            Bind<IQueryHandler<GetPostByDateQuery, Post>>().To<GetPostByDateQueryHandler>();
            Bind<IQueryHandler<GetPostsForCategoryQuery, PagedResult<Post>>>().To<GetPostsForCategoryQueryHandler>();
            Bind<IQueryHandler<GetPostsForSearchQuery, PagedResult<Post>>>().To<GetPostsForSearchQueryHandler>();
            Bind<IQueryHandler<GetPostsForTagQuery, PagedResult<Post>>>().To<GetPostsForTagQueryHandler>();

        }
    }
}
