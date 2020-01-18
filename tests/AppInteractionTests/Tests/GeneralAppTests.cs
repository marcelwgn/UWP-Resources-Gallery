using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AppInteractionTests.Tests
{
    [TestClass]
    public class GeneralAppTests
    {
        [TestMethod]
        public void SessionGetsInitialized()
        {
            Assert.IsNotNull(TestRunInitializer.Session);

            Assert.AreEqual("UWP Resources Gallery"
                , TestRunInitializer.Session.FindElementsByTagName("Text")[0].Text);
        }


        [TestMethod]
        public void VerifyCompactOverlayBehavior()
        {
            OpenQA.Selenium.Appium.Windows.WindowsElement compactOverlayButton = TestHelper.GetElementsOfTypeWithContent(
                "Button", "Switch to overlay mode")[0];
            Assert.IsNotNull(compactOverlayButton);

            // Switch to CompactOverlay
            compactOverlayButton.Click();
            TestHelper.WaitMilli(2000);

            // Get new button with updated text
            compactOverlayButton = TestHelper.GetElementsOfTypeWithContent(
                "Button", "Switch to normal mode")[0];
            Assert.IsNotNull(compactOverlayButton);

            // Switch to normal
            compactOverlayButton.Click();
            TestHelper.WaitMilli(2000);

            // Check if button has updated correctly
            compactOverlayButton = TestHelper.GetElementsOfTypeWithContent(
                "Button", "Switch to overlay mode")[0];
            Assert.IsNotNull(compactOverlayButton);
        }

    }
}
