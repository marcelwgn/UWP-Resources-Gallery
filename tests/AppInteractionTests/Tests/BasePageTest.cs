using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AppInteractionTests.Tests
{
    [TestClass]
    public abstract class BasePageTest
    {
        public abstract string NavigationName
        {
            get;
        }

        [TestInitialize]
        public void PageSetup()
        {
            if (!TestHelper.CurrentPageInNavigation().Equals(NavigationName, StringComparison.InvariantCulture))
            {
                TestHelper.NavigateToPage(NavigationName);
            }
        }
    }
}
