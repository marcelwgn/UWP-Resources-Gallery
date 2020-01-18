using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace AppInteractionTests.Tests
{
    [TestClass]
    public class IconsPageTests : BasePageTest
    {
        public override string NavigationName => "Icons";

        [TestMethod]
        public void RendersItems()
        {
            // Clear search before test!
            OpenQA.Selenium.Appium.Windows.WindowsElement searchIconsBox = TestRunInitializer.Session.FindElementsByName("Search icons:")[1];
            searchIconsBox.Clear();
            TestHelper.WaitMilli(500);

            ICollection<OpenQA.Selenium.Appium.Windows.WindowsElement> listItems = TestHelper.GetElementsOfType("ListItem");

            // Just checking a few
            Assert.IsTrue(0 < TestHelper.GetItemsWithContent(listItems, "GlobalNavigationButton").Count);
            Assert.IsTrue(0 < TestHelper.GetItemsWithContent(listItems, "E700").Count);
            Assert.IsTrue(0 < TestHelper.GetItemsWithContent(listItems, "Wifi").Count);
            Assert.IsTrue(0 < TestHelper.GetItemsWithContent(listItems, "E701").Count);
            Assert.IsTrue(0 < TestHelper.GetItemsWithContent(listItems, "Bluetooth").Count);
            Assert.IsTrue(0 < TestHelper.GetItemsWithContent(listItems, "E702").Count);
        }


        [TestMethod]
        public void FilterWorks()
        {
            string[] iconsToTest = new string[] { "AdjustHologram", "A", "DataSenseBar", "EmojiTabCelebrationObjects", "ED55" };

            OpenQA.Selenium.Appium.Windows.WindowsElement searchIconsBox = TestRunInitializer.Session.FindElementsByName("Search icons:")[1];

            Assert.IsNotNull(searchIconsBox);
            Assert.IsTrue(searchIconsBox.Displayed);
            Assert.IsTrue(searchIconsBox.Enabled);

            foreach (string icon in iconsToTest)
            {
                searchIconsBox.Clear();
                TestHelper.WaitMilli(500);

                searchIconsBox.SendKeys(icon);
                TestHelper.WaitMilli(500);

                Assert.IsTrue(0 < TestHelper.GetElementsOfTypeWithContent("ListItem", icon).Count);
                Assert.IsTrue(TestHelper.GetElementsOfTypeWithContent("ListItem", icon)[0].Displayed);
            }

        }
    }
}
