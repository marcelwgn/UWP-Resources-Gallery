using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UnitTesting.AppContainer;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace ControlTests.UITests
{
    [TestClass]
    public class SystemColorInformationTests
    {
        [UITestMethod]
        public void VerifyRenderedText()
        {
            var panel = (StackPanel)ControlsTestPage.Instance.FindName("SystemColorInformationPanel");
            var systemControlInformation = panel.Children[0];

            var rootStackPanel = VisualTreeHelper.GetChild(systemControlInformation, 0);
            var hexCodeGrid = VisualTreeHelper.GetChild(rootStackPanel, 0);

            var lightStackPanel = VisualTreeHelper.GetChild(hexCodeGrid, 0);
            Assert.AreEqual("col or Li gh", GetTextBlock(lightStackPanel).Text);
            
            var darkStackPanel = VisualTreeHelper.GetChild(hexCodeGrid, 1);
            Assert.AreEqual("col or Da rk", GetTextBlock(darkStackPanel).Text);
        }

        private TextBlock GetTextBlock(DependencyObject container)
        {
            var grid = VisualTreeHelper.GetChild(container, 1);
            return VisualTreeHelper.GetChild(grid, 0) as TextBlock;
        }
    }
}
