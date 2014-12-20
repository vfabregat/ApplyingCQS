
using System.Collections.Generic;
using System.Linq;
using JustBlog.Core.Infrastructure.Queries;
using JustBlog.Core.Objects;
using NHibernate;
using NHibernate.Linq;

namespace JustBlog.Core.Queries.Tags
{
    public class GetAllTagsQueryHandler : IQueryHandler<GetAllTagsQuery, IList<Tag>>
    {
        private readonly ISession session;
        public GetAllTagsQueryHandler(ISession session)
        {
            this.session = session;
        }
        public IList<Tag> Handle(GetAllTagsQuery query)
        {
            return session.Query<Tag>().OrderBy(p => p.Name).ToList();
        }
    }
}
