using JustBlog.Core.Infrastructure.Commands;
using JustBlog.Core.Objects;
using NHibernate;

namespace JustBlog.Core.Commands.Tags
{
    public class DeleteTagCommandHandler : ICommandHandler<DeleteTagCommand>
    {
        private readonly ISession session;
        public DeleteTagCommandHandler(ISession session)
        {
            this.session = session;
        }
        public void Handle(DeleteTagCommand command)
        {
            using (var tran = session.BeginTransaction())
            {
                var tag = session.Get<Tag>(command.Id);
                session.Delete(tag);
                tran.Commit();
            }
        }
    }
}
