
using JustBlog.Core.Objects;
namespace JustBlog.Core.Commands.Posts
{
    public class AddOrEditPostCommand
    {
        public Post Post { get; private set; }

        public AddOrEditPostCommand(Post post)
        {
            this.Post = post;
        }
    }
}
