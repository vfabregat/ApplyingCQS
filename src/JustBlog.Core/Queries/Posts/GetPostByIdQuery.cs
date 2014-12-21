
using JustBlog.Core.Infrastructure.Queries;
using JustBlog.Core.Objects;
namespace JustBlog.Core.Queries.Posts
{
    public class GetPostByIdQuery : IQuery<Post>
    {
        public int Id { get; private set; }
        public GetPostByIdQuery(int id)
        {
            this.Id = id;
        }
    }
}
