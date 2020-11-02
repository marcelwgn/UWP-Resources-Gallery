using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UWPResourcesGallery.AppInteractionTests.Tests
{
    [TestClass]
    public class StartPageTests : BasePageTest
    {
        public override string NavigationName => "Start";

        [TestMethod]
        public void RendersButtonsAndText()
        {
            // Verifying buttons exist
            Assert.IsNotNull(TestRunInitializer.Session.FindElementByName("Open IconsList page"));
            Assert.IsNotNull(TestRunInitializer.Session.FindElementByName("Open SystemBrushes page"));
        }

        [TestMethod]
        public void VerifyIconNavigation()
        {
            TestHelper.InvokeButton("Open Icons page");

            Assert.IsTrue(TestHelper.IsCurrentPage("Icons"));
        }

        [TestMethod]
        public void VerifySystemColorsNavigation()
        {
            TestHelper.InvokeButton("Open Systembrushes page");

            Assert.IsTrue(TestHelper.IsCurrentPage("Systembrushes"));
        }
    }
}
