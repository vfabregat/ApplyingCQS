using System.Collections.Generic;
using System.Linq;

namespace JustBlog.Core.Test.Queries
{
    public class QueryableList<T> : IQueryable<T>
    {
        internal List<T> data = new List<T>();
        public System.Collections.Generic.IEnumerator<T> GetEnumerator()
        {
            return data.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return data.GetEnumerator();
        }

        public System.Type ElementType
        {
            get { return data.AsQueryable().ElementType; }
        }

        public System.Linq.Expressions.Expression Expression
        {
            get { return data.AsQueryable().Expression; }
        }

        public IQueryProvider Provider
        {
            get { return data.AsQueryable().Provider; }
        }

    }
}
