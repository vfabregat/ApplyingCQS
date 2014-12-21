
namespace JustBlog.Core.Commands.Posts
{
    public class DeletePostCommand
    {
        public int Id { get; private set; }
        public DeletePostCommand(int id)
        {
            this.Id = id;
        }
    }
}
