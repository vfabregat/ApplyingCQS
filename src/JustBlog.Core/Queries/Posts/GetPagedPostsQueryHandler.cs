using System.Collections.Generic;
using System.Linq;
using JustBlog.Core.Infrastructure.Queries;
using JustBlog.Core.Objects;

namespace JustBlog.Core.Queries.Posts
{
    public class GetPagedPostsQueryHandler : IQueryHandler<GetPagedPostsQuery, IList<Post>>
    {
        public IList<Post> Handle(GetPagedPostsQuery query)
        {
            //var posts = _session.Query<Post>()
            //                      .Where(p => p.Published)
            //                      .OrderByDescending(p => p.PostedOn)
            //                      .Skip(pageNo * pageSize)
            //                      .Take(pageSize)
            //                      .Fetch(p => p.Category)
            //                      .ToList();

            //var postIds = posts.Select(p => p.Id).ToList();

            //return _session.Query<Post>()
            //      .Where(p => postIds.Contains(p.Id))
            //      .OrderByDescending(p => p.PostedOn)
            //      .FetchMany(p => p.Tags)
            //      .ToList();

            return Enumerable.Empty<Post>().ToList();
        }
    }
}
