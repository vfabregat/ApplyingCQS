
using System.Collections.Generic;
using JustBlog.Core.Infrastructure.Queries;
using JustBlog.Core.Objects;
namespace JustBlog.Core.Queries.Posts
{
    public class GetPagedPostsQuery : IQuery<IList<Post>>
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
