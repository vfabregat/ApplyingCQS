
using System.Linq;
using JustBlog.Core.Infrastructure.Queries;
using JustBlog.Core.Objects;
using NHibernate;
using NHibernate.Linq;

namespace JustBlog.Core.Queries.Posts
{
    public class GetPostByIdQueryHandler : IQueryHandler<GetPostByIdQuery, Post>
    {
        private readonly ISession session;
        public GetPostByIdQueryHandler(ISession session)
        {
            this.session = session;
        }
        public Post Handle(GetPostByIdQuery query)
        {
            return session.Get<Post>(query.Id);
        }
    }
}
