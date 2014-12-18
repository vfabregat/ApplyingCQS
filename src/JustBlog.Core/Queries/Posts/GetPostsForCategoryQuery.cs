
namespace JustBlog.Core.Queries.Posts
{
    public class GetPostsForCategoryQuery : GetPagedPostsQuery
    {
        public string CategorySlug { get; private set; }

        public GetPostsForCategoryQuery(string categorySlug, int pageNumber, int pageSize)
            : base(pageNumber, pageSize)
        {
            this.CategorySlug = categorySlug;
        }

    }
}
