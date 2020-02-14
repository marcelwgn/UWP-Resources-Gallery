using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace AppInteractionTests.Tests
{

    [TestClass]
    public class SystemColorsPageTests : BasePageTest
    {
        public override string NavigationName => "Systemcolors";

        [TestMethod]
        public void RendersBrushes()
        {
            string[] brushes = new string[] { "SystemAltHighColor", "SystemAltLowColor" };
            foreach (string brushName in brushes)
            {
                List<OpenQA.Selenium.Appium.Windows.WindowsElement> blocks = TestHelper.GetElementsOfTypeWithContent("Text", brushName);
                Assert.AreEqual(1, blocks.Count);

                Assert.IsTrue(brushName.Equals(blocks[0].Text, StringComparison.InvariantCulture));
            }
        }

        [TestMethod]
        public void FiltersBrushesCorrectly()
        {
            string[] brushesToSearch = new string[] { "ChromeHigh", "ErrorTextColor" };

            OpenQA.Selenium.Appium.Windows.WindowsElement searchIconsBox = TestRunInitializer.Session.FindElementsByName("Search system colors:")[1];

            Assert.IsNotNull(searchIconsBox);
            Assert.IsTrue(searchIconsBox.Displayed);
            Assert.IsTrue(searchIconsBox.Enabled);

            foreach (string brush in brushesToSearch)
            {
                searchIconsBox.Clear();
                TestHelper.WaitMilli(500);

                searchIconsBox.SendKeys(brush);
                TestHelper.WaitMilli(500);

                Assert.IsTrue(0 < TestHelper.GetElementsOfTypeWithContent("ListItem", brush).Count);
                Assert.IsTrue(TestHelper.GetElementsOfTypeWithContent("ListItem", brush)[0].Displayed);
            }
            searchIconsBox.Clear();
        }
    }
}
