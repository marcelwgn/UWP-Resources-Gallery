using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UnitTesting.AppContainer;
using UWPResourcesGallery.Controls.Common;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Automation;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace UWPResourcesGallery.ControlTests.UITests
{
    [TestClass]
    public class PageHeaderTests
    {
        private static readonly string[] HeaderTexts = new string[] { "CommonControls Test page"
            , "This is the test UI for common controls of the UWP Resources Gallery" };

        [UITestMethod]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Globalization", "CA1307:Specify StringComparison", Justification = "Testing just english strings here")]
        public void RendersCorrectly()
        {
            PageHeader pageHeader = (PageHeader)ControlsTestPage.Instance.FindName("StandardPageHeader");
            Assert.IsNotNull(pageHeader);

            // All entries false since default(bool) = false
            bool[] foundValues = new bool[HeaderTexts.Length];

            DependencyObject innerContainer = VisualTreeHelper.GetChild(pageHeader, 0);
            int childCount = VisualTreeHelper.GetChildrenCount(innerContainer);
            for (int childIndex = 0; childIndex < childCount; childIndex++)
            {
                TextBlock child = (TextBlock)VisualTreeHelper.GetChild(innerContainer, childIndex);
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

        [UITestMethod]
        public void SizingIsCorrectly()
        {
            PageHeader pageHeader = (PageHeader)ControlsTestPage.Instance.FindName("StandardPageHeader");
            PageHeader pageHeaderWithoutDescriptions = (PageHeader)ControlsTestPage.Instance.FindName("HeaderWithoutDescription");

            Assert.IsTrue(pageHeader.ActualHeight > pageHeaderWithoutDescriptions.ActualHeight + 14);
        }

    }
}
