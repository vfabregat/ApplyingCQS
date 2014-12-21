using JustBlog.Core.Infrastructure.Commands;
using JustBlog.Core.Objects;
using NHibernate;

namespace JustBlog.Core.Commands.Posts
{
    public class DeletePostCommandHandler : ICommandHandler<DeletePostCommand>
    {
        private readonly ISession session;
        public DeletePostCommandHandler(ISession session)
        {
            this.session = session;
        }

        public void Handle(DeletePostCommand command)
        {
            using (var tran = session.BeginTransaction())
            {
                var post = session.Get<Post>(command.Id);
                if (post != null) session.Delete(post);
                tran.Commit();
            }
        }
    }
}
