
using JustBlog.Core.Infrastructure.Queries;
using JustBlog.Core.Objects;
using JustBlog.Core.Objects.Dto;
namespace JustBlog.Core.Queries.Posts
{
    public class GetPagedPostsQuery : IQuery<PagedResult<Post>>
    {
        public int PageNumber { get; private set; }
        public int PageSize { get; private set; }
        public GetPagedPostsQuery(int pageNumber, int pageSize)
        {
            this.PageNumber = pageNumber;
            this.PageSize = PageSize;
        }
    }
}
