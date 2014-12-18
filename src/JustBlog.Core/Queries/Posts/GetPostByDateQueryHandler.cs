
using System.Linq;
using JustBlog.Core.Infrastructure.Queries;
using JustBlog.Core.Objects;
using NHibernate;
using NHibernate.Linq;

namespace JustBlog.Core.Queries.Posts
{
    public class GetPostByDateQueryHandler : IQueryHandler<GetPostByDateQuery, Post>
    {
        private readonly ISession session;
        public GetPostByDateQueryHandler(ISession session)
        {
            this.session = session;
        }
        public Post Handle(GetPostByDateQuery query)
        {
            var posts = session.Query<Post>()
                            .Where(p => p.PostedOn.Year == query.Year &&
                                p.PostedOn.Month == query.Month &&
                                p.UrlSlug.Equals(query.TitleSlug))
                            .Fetch(p => p.Category);

            posts.FetchMany(p => p.Tags).ToFuture();

            return posts.ToFuture().Single();
        }
    }
}
