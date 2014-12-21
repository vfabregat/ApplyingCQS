
using JustBlog.Core.Infrastructure.Commands;
using NHibernate;
namespace JustBlog.Core.Commands.Categories
{
    public class AddOrEditCategoryCommandHandler : ICommandHandler<AddOrEditCategoryCommand>
    {
        private readonly ISession session;
        public AddOrEditCategoryCommandHandler(ISession session)
        {
            this.session = session;
        }
        public void Handle(AddOrEditCategoryCommand command)
        {
            using (var tran = session.BeginTransaction())
            {
                session.SaveOrUpdate(command.Category);
                tran.Commit();
            }
        }
    }
}
