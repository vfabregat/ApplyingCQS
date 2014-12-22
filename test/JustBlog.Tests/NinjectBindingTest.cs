using System.Collections.Generic;
using JustBlog.Core.Commands.Posts;
using JustBlog.Core.Infrastructure;
using JustBlog.Core.Infrastructure.Commands;
using JustBlog.Core.Infrastructure.Data;
using JustBlog.Core.Infrastructure.Queries;
using JustBlog.Core.Objects;
using JustBlog.Core.Objects.Dto;
using JustBlog.Core.Queries.Categories;
using JustBlog.Core.Queries.Posts;
using JustBlog.Core.Queries.Tags;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;
using System.Linq;

namespace JustBlog.Core.Test
{
    [TestClass]
    public class NinjectBindingTest
    {

        [TestMethod]
        public void ResolveQueryHandlerTest()
        {
            var kernel = new StandardKernel(new RepositoryModule());

            var queryHandler = kernel.TryGet<IQueryHandler<GetPagedPostsQuery, PagedResult<Post>>>();

            Assert.IsNotNull(queryHandler);

        }

        [TestMethod]
        public void ResolveCategoryQueryHandlerTest()
        {
            var kernel = new StandardKernel(new RepositoryModule());

            var queryHandler = kernel.TryGet<IQueryHandler<GetAllCategoriesQuery, IList<Category>>>();

            Assert.IsNotNull(queryHandler);

        }

        [TestMethod]
        public void ResolveTagsQueryHandlerTest()
        {
            var kernel = new StandardKernel(new RepositoryModule());

            var queryHandler = kernel.TryGet<IQueryHandler<GetAllTagsQuery, IList<Tag>>>();

            Assert.IsNotNull(queryHandler);

        }

        [TestMethod]
        public void ResolveIDbContextTest()
        {
            var kernel = new StandardKernel(new RepositoryModule());

            var target = kernel.TryGet<IDbContext>();

            Assert.IsNotNull(target);
        }

        [TestMethod]
        public void ResolveIQueryProcessorTest()
        {
            var kernel = new StandardKernel(new RepositoryModule());

            var target = kernel.TryGet<IQueryProcessor>();

            Assert.IsNotNull(target);
        }

        [TestMethod]
        public void ResolveAddOrEditPostCommandHandlerTest()
        {
            var kernel = new StandardKernel(new RepositoryModule());

            var queryHandler = kernel.TryGet<ICommandHandler<AddOrEditPostCommand>>();

            Assert.IsNotNull(queryHandler);
        }

    }
}
