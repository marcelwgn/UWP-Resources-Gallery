
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UnitTesting.AppContainer;
using UWPResourcesGallery.Controls.Common;
using Windows.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace ControlTests.Tests
{
    [TestClass]
    public class DualThemePresenterTests
    {
        [UITestMethod]
        public void RendersContent()
        {
            var dualThemePresenter = (DualThemePresenter)ControlsTestPage.Instance.FindName("StandardDualThemePresenter");
            // Test that all orientations render the text with the right font
            foreach (var displayMode in Enum.GetValues(typeof(Orientation)))
            {
                dualThemePresenter.ContentOrientation = (Orientation)displayMode;
                dualThemePresenter.UpdateLayout();
                var lightTextBox = (TextBlock)ControlsTestPage.Instance.FindName("LightThemeText");
                Assert.IsNotNull(lightTextBox);
                Assert.AreEqual("Light", lightTextBox.Text);
                Assert.AreEqual(Colors.Black, (lightTextBox.Foreground as SolidColorBrush).Color);

                var darkTextBox = (TextBlock)ControlsTestPage.Instance.FindName("DarkThemeText");
                Assert.IsNotNull(darkTextBox);
                Assert.AreEqual("Dark", darkTextBox.Text);
                Assert.AreEqual(Colors.White, (darkTextBox.Foreground as SolidColorBrush).Color);
            }
        }
    }
}
