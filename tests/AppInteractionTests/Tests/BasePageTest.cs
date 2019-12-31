using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

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
            if (!TestHelper.CurrentPageInNavigation().Equals(NavigationName,StringComparison.InvariantCulture))
            {
                TestHelper.NavigateToPage(NavigationName);
            }
            var fittingItems = TestHelper.GetElementsOfTypeWithContent("ListItem", NavigationName);
            fittingItems[0].Click();
        }
    }
}
