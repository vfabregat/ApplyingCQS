using JustBlog.Core.Infrastructure.Commands;
using JustBlog.Core.Objects;
using NHibernate;

namespace JustBlog.Core.Commands.Categories
{
    public class DeleteCategoryCommandHandler : ICommandHandler<DeleteCategoryCommand>
    {
        private readonly ISession session;
        public DeleteCategoryCommandHandler(ISession session)
        {
            this.session = session;
        }
        public void Handle(DeleteCategoryCommand command)
        {
            using (var tran = session.BeginTransaction())
            {
                var category = session.Get<Category>(command.Id);
                session.Delete(category);
                tran.Commit();
            }
        }
    }
}
