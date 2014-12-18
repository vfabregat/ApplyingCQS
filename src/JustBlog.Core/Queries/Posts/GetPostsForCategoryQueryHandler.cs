using System.Linq;
using JustBlog.Core.Infrastructure.Queries;
using JustBlog.Core.Objects;
using JustBlog.Core.Objects.Dto;
using NHibernate;
using NHibernate.Linq;
namespace JustBlog.Core.Queries.Posts
{
    public class GetPostsForCategoryQueryHandler : IQueryHandler<GetPostsForCategoryQuery, PagedResult<Post>>
    {
        private readonly ISession session;

        public GetPostsForCategoryQueryHandler(ISession session)
        {
            this.session = session;
        }
        public PagedResult<Post> Handle(GetPostsForCategoryQuery query)
        {
            var posts = session.Query<Post>()
                                  .Where(p => p.Published && p.Category.UrlSlug.Equals(query.CategorySlug))
                                  .OrderByDescending(p => p.PostedOn)
                                  .Skip(query.PageNumber * query.PageSize)
                                  .Take(query.PageSize)
                                  .Fetch(p => p.Category)
                                  .ToList();

            var postIds = posts.Select(p => p.Id).ToList();

            var pageResult = new PagedResult<Post>();
            pageResult.Results =
                session.Query<Post>()
                  .Where(p => postIds.Contains(p.Id))
                  .OrderByDescending(p => p.PostedOn)
                  .FetchMany(p => p.Tags)
                  .ToList();
            pageResult.TotalResults = session.Query<Post>()
                          .Where(p => p.Published && p.Category.UrlSlug.Equals(query.CategorySlug))
                          .Count();

            return pageResult;
        }
    }
}
