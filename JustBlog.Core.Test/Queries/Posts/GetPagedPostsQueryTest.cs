using System;
using JustBlog.Core.Infrastructure.Data;
using JustBlog.Core.Objects;
using JustBlog.Core.Queries.Posts;
using JustBlog.Core.Test.Queries;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace JustBlog.Core.Test
{

    [TestClass]
    public class GetPagedPostQueryTest //: InMemoryDatabaseTest
    {
        public GetPagedPostQueryTest()
        //: base(typeof(Post).Assembly)
        {


        }
        [TestMethod]
        public void IfNotThereResultsThenReturnAnEmptyObject()
        {
            var query = new GetPagedPostsQuery(0, 10);

            //    var sessionMock = new Mock<ISession>();
            //    var queryMock = new Mock<IQuery>();
            //    var transactionMock = new Mock<ITransaction>();

            //    sessionMock.SetupGet(x => x.Transaction).Returns(transactionMock.Object);
            //    sessionMock.Setup(session => session.CreateQuery("from Post")).Returns(queryMock.Object);
            //    queryMock.Setup(x => x.List<Post>()).Returns(new List<Post>());


            var list = new QueryableList<Post>();
            list.data.Add(new Post()
            {
                Description = "description",
                PostedOn = DateTime.Now,
                Published = true,
                UrlSlug = "Post",
                Title = "Title",
                Category = new Category
                {
                    Description = "Programming",
                    Id = 1,
                    Name = "Programming",
                    UrlSlug = "Programming"
                }
            });
            var dataContext = new Mock<IDbContext>();
            dataContext.Setup(d => d.Query<Post>())
                .Returns(list);

            var queryHandler = new GetPagedPostsQueryHandler(dataContext.Object);

            var result = queryHandler.Handle(query);

            Assert.IsNotNull(result);
            //    Assert.AreEqual(15, result.TotalResults);
            //   Assert.AreEqual(10, result.Results.Count);
        }
    }
}
