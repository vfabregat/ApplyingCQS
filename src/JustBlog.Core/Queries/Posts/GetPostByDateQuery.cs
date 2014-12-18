
using JustBlog.Core.Infrastructure.Queries;
using JustBlog.Core.Objects;
namespace JustBlog.Core.Queries.Posts
{
    public class GetPostByDateQuery : IQuery<Post>
    {
        public int Year { get; private set; }
        public int Month { get; private set; }
        public string TitleSlug { get; private set; }

        public GetPostByDateQuery(int year, int month, string titleSlug)
        {
            this.Year = year;
            this.Month = month;
            this.TitleSlug = titleSlug;
        }
    }
}
