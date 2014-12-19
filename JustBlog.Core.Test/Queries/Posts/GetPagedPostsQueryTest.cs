using JustBlog.Core.Infrastructure.Data;
using JustBlog.Core.Queries.Posts;
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
            var query = new GetPagedPostsQuery(1, 10);

            //    var sessionMock = new Mock<ISession>();
            //    var queryMock = new Mock<IQuery>();
            //    var transactionMock = new Mock<ITransaction>();

            //    sessionMock.SetupGet(x => x.Transaction).Returns(transactionMock.Object);
            //    sessionMock.Setup(session => session.CreateQuery("from Post")).Returns(queryMock.Object);
            //    queryMock.Setup(x => x.List<Post>()).Returns(new List<Post>());
            var dataContext = new Mock<IDbContext>();
            var queryHandler = new GetPagedPostsQueryHandler(dataContext.Object);

            //    var result = queryHandler.Handle(query);

            //    Assert.IsNotNull(result);
            //    Assert.AreEqual(15, result.TotalResults);
            //    Assert.AreEqual(10, result.Results.Count);
        }
    }
}
