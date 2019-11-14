using ControlTests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AppInteractionTests
{
    [TestClass]
    public class InitializationTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            Assert.IsNotNull(TestRunInitializer.Session);

        }
    }
}
