using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UnitTesting.AppContainer;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace UWPResourcesGallery.Controls.Tests.UITests
{
    [TestClass]
    public class SystemColorInformationTests
    {
        [UITestMethod]
        public void VerifyRenderedText()
        {
            StackPanel panel = (StackPanel)ControlsTestPage.Instance.FindName("SystemColorInformationPanel");
            UIElement systemControlInformation = panel.Children[0];

            DependencyObject rootStackPanel = VisualTreeHelper.GetChild(systemControlInformation, 0);
            DependencyObject hexCodeGrid = VisualTreeHelper.GetChild(rootStackPanel, 0);

            DependencyObject lightStackPanel = VisualTreeHelper.GetChild(hexCodeGrid, 0);
            Assert.AreEqual("col or Li gh", GetTextBlock(lightStackPanel).Text);

            DependencyObject darkStackPanel = VisualTreeHelper.GetChild(hexCodeGrid, 1);
            Assert.AreEqual("col or Da rk", GetTextBlock(darkStackPanel).Text);
        }

        private static TextBlock GetTextBlock(DependencyObject container)
        {
            DependencyObject grid = VisualTreeHelper.GetChild(container, 1);
            return VisualTreeHelper.GetChild(grid, 0) as TextBlock;
        }
    }
}
