
using JustBlog.Core.Infrastructure.Queries;
using JustBlog.Core.Objects;
using JustBlog.Core.Objects.Dto;
namespace JustBlog.Core.Queries.Posts
{
    public class GetPagedPostsQuery : IQuery<PagedResult<Post>>
    {
        public int PageNumber { get; private set; }
        public int PageSize { get; private set; }
        public string SortColumn { get; private set; }
        public bool SortByAscending { get; private set; }
        public bool CountCheckIsPublished { get; private set; }

        public GetPagedPostsQuery(int pageNumber, int pageSize, string sortColumn = "", bool sortByAscending = false, bool countCheckIsPublished = true)
        {
            this.PageNumber = pageNumber;
            this.PageSize = pageSize;
            this.SortColumn = sortColumn;
            this.SortByAscending = sortByAscending;
            this.CountCheckIsPublished = countCheckIsPublished;
        }
    }
}
