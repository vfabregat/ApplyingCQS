
namespace JustBlog.Core.Commands.Tags
{
    public class DeleteTagCommand
    {
        public int Id { get; private set; }
        public DeleteTagCommand(int id)
        {
            this.Id = id;
        }
    }
}
