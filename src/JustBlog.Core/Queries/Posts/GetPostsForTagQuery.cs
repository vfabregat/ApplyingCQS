
namespace JustBlog.Core.Queries.Posts
{
    public class GetPostsForTagQuery : GetPagedPostsQuery
    {
        public string TagSlug { get; private set; }

        public GetPostsForTagQuery(string tagSlug, int pageNumber, int pageSize)
            : base(pageNumber, pageSize)
        {
            this.TagSlug = tagSlug;
        }

    }
}
