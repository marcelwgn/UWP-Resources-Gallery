using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace AppInteractionTests.Tests
{

    [TestClass]
    public class SystemBrushesPageTests : BasePageTest
    {
        public override string NavigationName => "Systembrushes";

        [TestMethod]
        public void RendersBrushes()
        {
            OpenQA.Selenium.Appium.Windows.WindowsElement searchIconsBox = TestRunInitializer.Session.FindElementsByName("Search system brushes:")[1];
            searchIconsBox.Clear();
            TestHelper.WaitMilli(500); 
            
            string[] brushes = new string[] { "SystemControlBackgroundAccentBrush", "SystemControlBackgroundAltHighBrush" };
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
            string[] brushesToSearch = new string[] { "Description", "Transparent", "Medium" };

            OpenQA.Selenium.Appium.Windows.WindowsElement searchIconsBox = TestRunInitializer.Session.FindElementsByName("Search system brushes:")[1];

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
