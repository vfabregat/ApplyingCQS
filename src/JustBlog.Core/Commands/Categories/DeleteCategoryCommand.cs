
namespace JustBlog.Core.Commands.Categories
{
    public class DeleteCategoryCommand
    {
        public int Id { get; private set; }
        public DeleteCategoryCommand(int id)
        {
            this.Id = id;
        }
    }
}
