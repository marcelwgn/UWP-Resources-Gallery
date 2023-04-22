using Axe.Windows.Automation.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Threading;

namespace UWPResourcesGallery.AppInteractionTests.Tests
{
    [TestClass]
    public abstract class BasePageTest
    {
        public abstract string NavigationName
        {
            get;
        }

        [ClassInitialize]
        public static void AppLaunch(TestContext _)
        {
            TestRunInitializer.Session.Manage().Window.Maximize();
        }

        [TestInitialize]
        public void PageSetup()
        {
            TestRunInitializer.Session.Manage().Window.Maximize();
            var result = TestRunInitializer.AccessibilityScanner.Scan(new ScanOptions());
            Assert.AreEqual(0, result.WindowScanOutputs.Sum(output => output.ErrorCount));
            if (!TestHelper.IsCurrentPage(NavigationName))
            {
                TestHelper.NavigateToPage(NavigationName);
                result = TestRunInitializer.AccessibilityScanner.Scan(new ScanOptions());
                Assert.AreEqual(0, result.WindowScanOutputs.Sum(output => output.ErrorCount));
            }
            Thread.Sleep(TimeSpan.FromSeconds(1));
        }

        [ClassCleanup]
        public static void AppTearDown()
        {
            TestHelper.NavigateToPage("Start");
            TestRunInitializer.TearDown();
        }
    }
}
