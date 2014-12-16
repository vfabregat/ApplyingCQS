using JustBlog.Core.Infrastructure.Queries;

namespace JustBlog.Core.Infrastructure
{
    public interface IQueryProcessor
    {
        TResult Execute<TResult>(IQuery<TResult> query);
    }
}
