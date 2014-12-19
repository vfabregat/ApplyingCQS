using System.Linq;
using JustBlog.Core.Infrastructure.Data;
using JustBlog.Core.Infrastructure.Queries;
using JustBlog.Core.Objects;
using JustBlog.Core.Objects.Dto;
using NHibernate;
using NHibernate.Linq;
namespace JustBlog.Core.Queries.Posts
{
    /// <summary>
    /// 
    /// </summary>
    public class GetPagedPostsQueryHandler : IQueryHandler<GetPagedPostsQuery, PagedResult<Post>>
    {
        private readonly ISession session;
        private readonly IDbContext dbContext;
        public GetPagedPostsQueryHandler(IDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public GetPagedPostsQueryHandler(ISession session)
        {
            this.session = session;
        }
        public PagedResult<Post> Handle(GetPagedPostsQuery query)
        {
            var result = new PagedResult<Post>();

            var posts = session.Query<Post>()
                                  .Where(p => p.Published)
                                  .PagedToList(query.PageNumber, query.PageSize); ;

            var postIds = posts.Select(p => p.Id).ToList();

            result.Results = session.Query<Post>()
                              .Where(p => postIds.Contains(p.Id))
                              .OrderByDescending(p => p.PostedOn)
                              .FetchMany(p => p.Tags)
                              .ToList();
            return result;

        }
    }
}
