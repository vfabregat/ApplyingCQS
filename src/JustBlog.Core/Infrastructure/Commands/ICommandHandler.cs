
namespace JustBlog.Core.Infrastructure.Commands
{
    public interface ICommandHandler<TCommand>
    {
        void Handle(TCommand command);
    }
}
