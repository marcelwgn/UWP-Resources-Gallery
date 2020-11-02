using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace UWPResourcesGallery.AppInteractionTests.Tests
{

    [TestClass]
    public class SystemColorsPageTests : BasePageTest
    {
        public override string NavigationName => "Systemcolors";

        [TestMethod]
        public void RendersColors()
        {
            OpenQA.Selenium.Appium.Windows.WindowsElement searchIconsBox = TestRunInitializer.Session.FindElementByAccessibilityId("SearchColorsInput");
            searchIconsBox.Clear();
            TestHelper.WaitMilli(500);

            string[] colors = new string[] { "AltHigh", "AltLow" };
            foreach (string color in colors)
            {
                var uiElement = TestRunInitializer.Session.FindElementByName("System color " + color);
                Assert.IsNotNull(uiElement);
            }
        }

        [TestMethod]
        public void FiltersColorsCorrectly()
        {
            // Not using DataTestMethod as the initial steps are very expensive
            Tuple<string, string>[] colorsToSearch = new Tuple<string, string>[] {
                new Tuple<string,string>("ChromeHigh","ChromeHigh"),
                new Tuple<string,string>("ErrorTextColor","ErrorText"),
                new Tuple<string,string>("Accent","Accent") };

            OpenQA.Selenium.Appium.Windows.WindowsElement searchIconsBox = TestRunInitializer.Session.FindElementByAccessibilityId("SearchColorsInput");
            Assert.IsNotNull(searchIconsBox);
            Assert.IsTrue(searchIconsBox.Displayed);
            Assert.IsTrue(searchIconsBox.Enabled);

            foreach (var search in colorsToSearch)
            {
                searchIconsBox.Clear();
                TestHelper.WaitMilli(500);

                searchIconsBox.SendKeys(search.Item1);
                TestHelper.WaitMilli(500);

                Assert.IsNotNull(TestRunInitializer.Session.FindElementByName("System color " + search.Item2));
                Assert.IsTrue(TestRunInitializer.Session.FindElementByName("System color " + search.Item2).Displayed);
            }
            searchIconsBox.Clear();
        }
    }
}
