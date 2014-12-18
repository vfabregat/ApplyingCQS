using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JustBlog.Core.Test
{
    //[TestClass]
    public class Startup
    {
        static InMemoryDatabaseTest memoryDatabase;

        [AssemblyInitializeAttribute]
        public static void Initialize(TestContext context)
        {
            //memoryDatabase = new InMemoryDatabaseTest(typeof(Post).Assembly);

        }

        [AssemblyCleanup]
        public static void TearDownTestRun()
        {


        }
    }
}
