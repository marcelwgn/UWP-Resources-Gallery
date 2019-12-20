using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AppInteractionTests.Tests
{
    [TestClass]
    public class InitializationTests
    {
        [TestMethod]
        public void SessionGetsInitialized()
        {
            Assert.IsNotNull(TestRunInitializer.Session);

            Assert.AreEqual("UWP Resources Gallery"
                , TestRunInitializer.Session.FindElementsByTagName("Text")[0].Text);
        }
    }
}
