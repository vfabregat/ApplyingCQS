
using System.Collections.Generic;
using System.Linq;
using JustBlog.Core.Objects;
using NHibernate.Linq;

namespace JustBlog.Core
{
    public static class IQueryableExtensions
    {
        public static List<Post> PagedToList(this IQueryable<Post> queryable, int pageNumber, int pageSize)
        {
            return queryable.OrderByDescending(p => p.PostedOn)
                                  .Skip(pageNumber * pageSize)
                                  .Take(pageSize)
                                  .Fetch(p => p.Category)
                                  .ToList();
        }
    }
}
