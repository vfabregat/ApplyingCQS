using System.Linq;
using NHibernate;
using NHibernate.Linq;

namespace JustBlog.Core.Infrastructure.Data
{
    public class DbContext : IDbContext
    {
        ISession session;
        public DbContext(ISession session)
        {
            this.session = session;
        }

        public IQueryable<T> Query<T>()
        {
            return session.Query<T>();
        }
    }
}
