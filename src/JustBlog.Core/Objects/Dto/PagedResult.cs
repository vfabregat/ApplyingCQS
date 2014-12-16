using System.Collections.Generic;

namespace JustBlog.Core.Objects.Dto
{
    public class PagedResult<TResult>
    {
        public IList<TResult> Results { get; set; }
        public int TotalResults { get; set; }
    }
}
