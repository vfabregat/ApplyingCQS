using System.Linq;
using JustBlog.Core.Infrastructure.Queries;
using JustBlog.Core.Objects;
using JustBlog.Core.Objects.Dto;
using NHibernate;
using NHibernate.Linq;
namespace JustBlog.Core.Queries.Posts
{
    public class GetPostsForSearchQueryHandler : IQueryHandler<GetPostsForSearchQuery, PagedResult<Post>>
    {
        private readonly ISession session;

        public GetPostsForSearchQueryHandler(ISession session)
        {
            this.session = session;
        }
        public PagedResult<Post> Handle(GetPostsForSearchQuery query)
        {
            var pagedResult = new PagedResult<Post>();

            var posts = session.Query<Post>()
                                  .Where(p => p.Published && (p.Title.Contains(query.Search) ||
                                                p.Category.Name.Equals(query.Search) ||
                                                p.Tags.Any(t => t.Name.Equals(query.Search))))
                                  .PagedToList(query.PageNumber, query.PageSize);

            var postIds = posts.Select(p => p.Id).ToList();

            pagedResult.Results = session.Query<Post>()
                  .Where(p => postIds.Contains(p.Id))
                  .OrderByDescending(p => p.PostedOn)
                  .FetchMany(p => p.Tags)
                  .ToList();
            return pagedResult;
        }
    }
}
