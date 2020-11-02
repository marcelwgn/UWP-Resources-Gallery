using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace UWPResourcesGallery.AppInteractionTests.Tests
{
    [TestClass]
    public class IconsPageTests : BasePageTest
    {
        public override string NavigationName => "Icons";

        [TestMethod]
        public void RendersItems()
        {
            // Clear search before test!
            OpenQA.Selenium.Appium.Windows.WindowsElement searchIconsBox = TestRunInitializer.Session.FindElementByAccessibilityId("SearchIconsInput");
            searchIconsBox.Clear();
            TestHelper.WaitMilli(500);

            var rootGrid = TestRunInitializer.Session.FindElementByName("Icons");

            // Just checking a few
            Assert.IsNotNull(rootGrid.FindElementByName("Icon GlobalNavigationButton"));
            Assert.IsNotNull(rootGrid.FindElementByName("Icon Wifi"));
            Assert.IsNotNull(rootGrid.FindElementByName("Icon Bluetooth"));
        }


        [TestMethod]
        public void FilterWorks()
        {
            Tuple<string, string>[] iconsToTest = new Tuple<string, string>[] {
                new Tuple<string,string>("AdjustHologram","AdjustHologram"),
                new Tuple<string,string>("A","GlobalNavigationButton"),
                new Tuple<string,string>("DataSenseBar","DataSenseBar"),
                new Tuple<string,string>("EmojiTabCelebrationObjects","EmojiTabCelebrationObjects"),
                new Tuple<string,string>("ED55","EmojiTabCelebrationObjects")};


            OpenQA.Selenium.Appium.Windows.WindowsElement searchIconsBox = TestRunInitializer.Session.FindElementByAccessibilityId("SearchIconsInput");

            Assert.IsNotNull(searchIconsBox);
            Assert.IsTrue(searchIconsBox.Displayed);
            Assert.IsTrue(searchIconsBox.Enabled);

            foreach (var search in iconsToTest)
            {
                searchIconsBox.Clear();
                TestHelper.WaitMilli(500);

                searchIconsBox.SendKeys(search.Item1);
                TestHelper.WaitMilli(500);

                Assert.IsNotNull(TestRunInitializer.Session.FindElementByName("Icon " + search.Item2));
                Assert.IsTrue(TestRunInitializer.Session.FindElementByName("Icon " + search.Item2).Displayed);
            }
        }

        [TestMethod]
        public void OnlySymbolsFilterWorksCorrectly()
        {
            OpenQA.Selenium.Appium.Windows.WindowsElement searchIconsBox = TestRunInitializer.Session.FindElementByAccessibilityId("SearchIconsInput");
            OpenQA.Selenium.Appium.Windows.WindowsElement symbolsOnlyCheckbox = TestRunInitializer.Session.FindElementByName("Only show symbols");
            symbolsOnlyCheckbox.Click();

            Assert.IsNotNull(searchIconsBox);
            Assert.IsTrue(searchIconsBox.Displayed);
            Assert.IsTrue(searchIconsBox.Enabled);

            searchIconsBox.Clear();
            TestHelper.WaitMilli(500);

            searchIconsBox.SendKeys("Global");
            TestHelper.WaitMilli(500);

            var globalIcon = TestRunInitializer.Session.FindElementByName("Icon GlobalNavigationButton");
            Assert.IsNotNull(globalIcon);
            Assert.IsTrue(globalIcon.Displayed);

            searchIconsBox.Clear();
            TestHelper.WaitMilli(500);

            searchIconsBox.SendKeys("ED55");
            TestHelper.WaitMilli(500);

            bool crashed = true;
            try
            {
                TestRunInitializer.Session.FindElementByName("Icon EmojiTabCelebrationObjects");
                crashed = false;
            } catch (OpenQA.Selenium.WebDriverException) { }

            // Element not found, thus selenium threw an exception
            Assert.IsTrue(crashed);
            searchIconsBox.Clear();
            symbolsOnlyCheckbox.Click();
        }
    }
}
