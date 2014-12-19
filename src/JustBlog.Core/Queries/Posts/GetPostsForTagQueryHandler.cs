using System.Linq;
using JustBlog.Core.Infrastructure.Queries;
using JustBlog.Core.Objects;
using JustBlog.Core.Objects.Dto;
using NHibernate;
using NHibernate.Linq;
namespace JustBlog.Core.Queries.Posts
{
    public class GetPostsForTagQueryHandler : IQueryHandler<GetPostsForTagQuery, PagedResult<Post>>
    {
        private readonly ISession session;

        public GetPostsForTagQueryHandler(ISession session)
        {
            this.session = session;
        }
        public PagedResult<Post> Handle(GetPostsForTagQuery query)
        {
            var pagedResult = new PagedResult<Post>();

            var posts = session.Query<Post>()
                            .Where(p => p.Published && p.Tags.Any(t => t.UrlSlug.Equals(query.TagSlug)))
                            .PagedToList(query.PageNumber, query.PageSize);

            var postIds = posts.Select(p => p.Id).ToList();

            pagedResult.Results = session.Query<Post>()
                  .Where(p => postIds.Contains(p.Id))
                  .OrderByDescending(p => p.PostedOn)
                  .FetchMany(p => p.Tags)
                  .ToList();

            pagedResult.TotalResults = session.Query<Post>()
                           .Where(p => p.Published && p.Tags.Any(t => t.UrlSlug.Equals(query.TagSlug)))
                           .Count();

            return pagedResult;
        }
    }
}
