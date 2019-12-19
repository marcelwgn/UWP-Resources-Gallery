using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UnitTesting.AppContainer;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWPResourcesGallery.Controls.Common;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Automation;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace ControlTests.Tests
{
    [TestClass]
    public class PageHeaderTests
    {
        private static readonly string[] HeaderTexts = new string[] { "CommonControls Test page"
            , "This is the test page/app for common controls used in the UWP Resources Gallery" };

        [UITestMethod]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Globalization", "CA1307:Specify StringComparison", Justification = "Testing just english strings here")]
        public void RendersCorrectly()
        {
            var pageHeader = (PageHeader)ControlsTestPage.Instance.FindName("StandardPageHeader");
            Assert.IsNotNull(pageHeader);

            // All entries false since default(bool) = false
            bool[] foundValues = new bool[HeaderTexts.Length];

            var innerContainer = VisualTreeHelper.GetChild(pageHeader, 0);
            int childCount = VisualTreeHelper.GetChildrenCount(innerContainer);
            for (int childIndex = 0; childIndex < childCount; childIndex++)
            {
                var child = (TextBlock)VisualTreeHelper.GetChild(innerContainer, childIndex);
                if (child == null)
                {
                    continue;
                }
                for (int textIndex = 0; textIndex < HeaderTexts.Length; textIndex++)
                {
                    if (child.Text.Equals(HeaderTexts[textIndex]))
                    {
                        // Verify that the heading level is correct for the given text
                        // HeadingLevel starts at 1 so we need to add 1 to the current index
                        Assert.AreEqual(textIndex + 1, (int)child.GetValue(AutomationProperties.HeadingLevelProperty));
                        foundValues[textIndex] = true;
                    }
                }
            }

            // Verify all found
            for (int i = 0; i < foundValues.Length; i++)
            {
                Assert.IsTrue(foundValues[i]);
            }

        }
    }
}
