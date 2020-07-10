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
            OpenQA.Selenium.Appium.Windows.WindowsElement searchIconsBox = TestRunInitializer.Session.FindElementByAccessibilityId("SearchBrushesInput");
            searchIconsBox.Clear();
            TestHelper.WaitMilli(500); 
            
            string[] brushes = new string[] { "SystemControlBackgroundAccentBrush", "SystemControlBackgroundAltHighBrush" };
            foreach (string brushName in brushes)
            {
                var uiElement = TestRunInitializer.Session.FindElementByName("System brush " + brushName);
                Assert.IsNotNull(uiElement);
            }
        }

        [TestMethod]
        public void FiltersBrushesCorrectly()
        {
            // Not using DataTestMethod as the initial steps are very expensive
            Tuple<string, string>[] brushesToSearch = new Tuple<string, string>[] {
                new Tuple<string,string>("Description","SystemControlDescriptionTextForegroundBrush"),
                new Tuple<string,string>("Transparent","SystemControlDisabledTransparentBrush"),
                new Tuple<string,string>("Medium","SystemControlBackgroundAltMediumHighBrush") };

            OpenQA.Selenium.Appium.Windows.WindowsElement searchIconsBox = TestRunInitializer.Session.FindElementByAccessibilityId("SearchBrushesInput");

            Assert.IsNotNull(searchIconsBox);
            Assert.IsTrue(searchIconsBox.Displayed);
            Assert.IsTrue(searchIconsBox.Enabled);

            foreach (var search in brushesToSearch)
            {
                searchIconsBox.Clear();
                TestHelper.WaitMilli(500);

                searchIconsBox.SendKeys(search.Item1);
                TestHelper.WaitMilli(500);
                
                Assert.IsNotNull(TestRunInitializer.Session.FindElementByName("System brush " + search.Item2));
                Assert.IsTrue(TestRunInitializer.Session.FindElementByName("System brush " + search.Item2).Displayed);
            }
            
            searchIconsBox.Clear();
        }
    }
}
