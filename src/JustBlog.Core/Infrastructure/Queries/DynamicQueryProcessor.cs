
using System.Diagnostics;
using JustBlog.Core.Infrastructure.Queries;
using Ninject;

namespace JustBlog.Core.Infrastructure
{
    /// <summary>
    /// 
    /// </summary>
    public class DynamicQueryProcessor : IQueryProcessor
    {
        private readonly IKernel container;

        public DynamicQueryProcessor(IKernel container)
        {
            this.container = container;
        }

        [DebuggerStepThrough]
        public TResult Execute<TResult>(IQuery<TResult> query)
        {
            var handlerType = typeof(IQueryHandler<,>).MakeGenericType(query.GetType(), typeof(TResult));

            dynamic handler = this.container.Get(handlerType);

            return handler.Handle((dynamic)query);
        }
    }
}
