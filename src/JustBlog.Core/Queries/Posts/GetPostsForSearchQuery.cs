
namespace JustBlog.Core.Queries.Posts
{
    public class GetPostsForSearchQuery : GetPagedPostsQuery
    {
        public string Search { get; private set; }

        public GetPostsForSearchQuery(string search, int pageNumber, int pageSize)
            : base(pageNumber, pageSize)
        {
            this.Search = search;
        }

    }
}
