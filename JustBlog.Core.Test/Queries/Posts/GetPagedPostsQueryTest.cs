using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JustBlog.Core.Test
{
    [TestClass]
    public class GetPagedPostQueryTest //: InMemoryDatabaseTest
    {
        public GetPagedPostQueryTest()
        //: base(typeof(Post).Assembly)
        {


        }
        //[TestMethod]
        //public void IfNotThereResultsThenReturnAnEmptyObject()
        //{
        //    var query = new GetPagedPostsQuery(1, 10);

        //    var sessionMock = new Mock<ISession>();
        //    var queryMock = new Mock<IQuery>();
        //    var transactionMock = new Mock<ITransaction>();

        //    sessionMock.SetupGet(x => x.Transaction).Returns(transactionMock.Object);
        //    sessionMock.Setup(session => session.CreateQuery("from Post")).Returns(queryMock.Object);
        //    queryMock.Setup(x => x.List<Post>()).Returns(new List<Post>());

        //    var queryHandler = new GetPagedPostsQueryHandler(sessionMock.Object);

        //    var result = queryHandler.Handle(query);

        //    Assert.IsNotNull(result);
        //    Assert.AreEqual(15, result.TotalResults);
        //    Assert.AreEqual(10, result.Results.Count);
        //}
    }
}
