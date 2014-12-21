using JustBlog.Core.Infrastructure.Commands;
using NHibernate;

namespace JustBlog.Core.Commands.Posts
{
    public class AddOrEditPostCommandHandler : ICommandHandler<AddOrEditPostCommand>
    {
        private readonly ISession session;
        public AddOrEditPostCommandHandler(ISession session)
        {
            this.session = session;
        }
        public void Handle(AddOrEditPostCommand command)
        {
            using (var tran = session.BeginTransaction())
            {
                session.SaveOrUpdate(command.Post);
                tran.Commit();
            }
        }
    }
}
