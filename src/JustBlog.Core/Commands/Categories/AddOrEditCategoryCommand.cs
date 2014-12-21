using JustBlog.Core.Objects;

namespace JustBlog.Core.Commands.Categories
{
    public class AddOrEditCategoryCommand
    {
        public readonly Category Category { get; private set; }
        public AddOrEditCategoryCommand(Category category)
        {
            this.Category = category;
        }
    }
}
