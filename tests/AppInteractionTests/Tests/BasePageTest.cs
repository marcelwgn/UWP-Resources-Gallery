using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading;

namespace AppInteractionTests.Tests
{
    [TestClass]
    public abstract class BasePageTest
    {
        public abstract string NavigationName
        {
            get;
        }

        [ClassInitialize]
        public static void AppLaunch()
        {
            TestRunInitializer.Session.Manage().Window.Maximize();
        }

        [TestInitialize]
        public void PageSetup()
        {
            TestRunInitializer.Session.Manage().Window.Maximize();
            if (!TestHelper.CurrentPageInNavigation().Equals(NavigationName, StringComparison.InvariantCulture))
            {
                TestHelper.NavigateToPage(NavigationName);
            }
            Thread.Sleep(TimeSpan.FromSeconds(10));
        }

        [ClassCleanup]
        public static void AppTearDown()
        {
            TestHelper.NavigateToPage("Start");
            TestRunInitializer.TearDown();
        }
    }
}
