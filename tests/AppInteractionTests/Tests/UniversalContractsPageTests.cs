using Castle.Core.Internal;
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
        [DataRow("1507","Windows Build 10240","UWP contract Windows.Foundation.FoundationContract")]
        [DataRow("1507 AI","","")]
        [DataRow("1507 connect", "Windows Build 10240", "UWP contract Windows.Networking.Connectivity.WwanContract")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "<Pending>")]
        public void FindsResults(string search, string foundVersion, string foundContract)
        {
            OpenQA.Selenium.Appium.Windows.WindowsElement searchContractsBox = TestRunInitializer.Session.FindElementByAccessibilityId("SearchUWPContractsInput");
            searchContractsBox.Clear();
            TestHelper.WaitMilli(500);

            foreach(char c in search.ToCharArray())
            {
                searchContractsBox.SendKeys(c.ToString());
                TestHelper.WaitMilli(100);
            }

            if(foundVersion.IsNullOrEmpty())
            {
                Assert.IsNotNull("No contracts found");
            }
            else
            {
                Assert.IsNotNull(TestRunInitializer.Session.FindElementByName(foundVersion));
                Assert.IsNotNull(TestRunInitializer.Session.FindElementByName(foundContract));
            }
        }


        [DataTestMethod]
        public void FindsContractsCorrectly()
        {
            Tuple<string, string>[] contractsToSearch = new Tuple<string, string>[]
            {
                new Tuple<string, string>("AI","UWP contract Windows.AI.MachineLearning.Preview.MachineLearningPreviewContract")
            };
            OpenQA.Selenium.Appium.Windows.WindowsElement searchContractsBox = TestRunInitializer.Session.FindElementByAccessibilityId("SearchUWPContractsInput");
            searchContractsBox.Clear();
            TestHelper.WaitMilli(500);

            foreach(var search in contractsToSearch)
            {
                searchContractsBox.SendKeys(search.Item1);
                TestHelper.WaitMilli(500);

                Assert.IsNotNull(TestRunInitializer.Session.FindElementByName(search.Item2));
            }
        }
    }
}
