using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppInteractionTests.Tests
{
    [TestClass]
    public class UniversalContractsPageTests : BasePageTest
    {
        public override string NavigationName => "Universal API contracts";

        [DataTestMethod]
        [DataRow("1507",1)]
        [DataRow("1507 AI",0)]
        [DataRow("1507 dasd sadiosadosa",0)]
        [DataRow("1507 contract",1)]
        public void FindsResults(string search, int foundItems)
        {
            OpenQA.Selenium.Appium.Windows.WindowsElement searchContractsBox = TestRunInitializer.Session.FindElementsByName("Search contracts and versions:")[1];
            searchContractsBox.Clear();
            TestHelper.WaitMilli(500);

            foreach(char c in search.ToCharArray())
            {
                searchContractsBox.SendKeys(c.ToString());
                TestHelper.WaitMilli(100);
            }
            TestHelper.WaitMilli(500);

            if(foundItems == 0)
            {
                var noText = TestHelper.GetElementsOfTypeWithContent("Text", "No");
                Assert.AreEqual(1, noText.Count);
            }
            else
            {
                var getItems = TestHelper.GetElementsOfTypeWithContent("Text","Build version");
                // There is always a build version present
                Assert.AreEqual(foundItems + 1,getItems.Count);
            }
        }


        [DataTestMethod]
        [DataRow("AI")]
        public void FindsContractsCorrectly(string contractname)
        {
            OpenQA.Selenium.Appium.Windows.WindowsElement searchContractsBox = TestRunInitializer.Session.FindElementsByName("Search contracts and versions:")[1];
            searchContractsBox.Clear();
            TestHelper.WaitMilli(500);

            searchContractsBox.SendKeys(contractname);
            TestHelper.WaitMilli(500);

            var getItems = TestHelper.GetElementsOfTypeWithContent("Text", contractname);
            Assert.AreEqual(1, getItems.Count);
        }
    }
}
