using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading;

namespace AppInteractionTests.Tests
{
    [TestClass]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "class intialize/cleanup can be non static")]
    public abstract class BasePageTest
    {
        public abstract string NavigationName
        {
            get;
        }

        [ClassInitialize]
        public void AppLaunch()
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
        public void AppTearDown()
        {
            TestHelper.NavigateToPage("Start");
            TestRunInitializer.TearDown();
        }
    }
}
