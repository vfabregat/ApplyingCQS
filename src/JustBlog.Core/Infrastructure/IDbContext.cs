namespace JustBlog.Core.Infrastructure.Data
{
    public interface IDbContext
    {
        global::System.Linq.IQueryable<T> Query<T>();
    }
}
