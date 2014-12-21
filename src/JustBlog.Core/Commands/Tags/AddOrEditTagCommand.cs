using JustBlog.Core.Objects;

namespace JustBlog.Core.Commands.Tags
{
    public class AddOrEditTagCommand
    {
        public Tag Tag { get; private set; }

        public AddOrEditTagCommand(Tag tag)
        {
            this.Tag = tag;
        }
    }
}
