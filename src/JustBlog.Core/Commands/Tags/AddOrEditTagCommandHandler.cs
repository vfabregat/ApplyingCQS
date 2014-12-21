using JustBlog.Core.Infrastructure.Commands;
using NHibernate;

namespace JustBlog.Core.Commands.Tags
{
    public class AddOrEditTagCommandHandler : ICommandHandler<AddOrEditTagCommand>
    {
        private readonly ISession session;
        public AddOrEditTagCommandHandler(ISession session)
        {
            this.session = session;
        }

        public void Handle(AddOrEditTagCommand command)
        {
            using (var tran = session.BeginTransaction())
            {
                session.SaveOrUpdate(command.Tag);
                tran.Commit();
            }
        }
    }
}
