
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UnitTesting.AppContainer;
using System;
using UWPResourcesGallery.Controls.Common;
using Windows.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace UWPResourcesGallery.ControlTests.UITests
{
    [TestClass]
    public class DualThemePresenterTests
    {
        [UITestMethod]
        public void RendersContent()
        {
            DualThemePresenter dualThemePresenter = (DualThemePresenter)ControlsTestPage.Instance.FindName("StandardDualThemePresenter");
            // Test that all orientations render the text with the right font
            foreach (object displayMode in Enum.GetValues(typeof(Orientation)))
            {
                dualThemePresenter.ContentOrientation = (Orientation)displayMode;
                dualThemePresenter.UpdateLayout();
                TextBlock lightTextBox = (TextBlock)ControlsTestPage.Instance.FindName("LightThemeText");
                Assert.IsNotNull(lightTextBox);
                Assert.AreEqual("Light", lightTextBox.Text);
                Assert.AreEqual(Colors.Black, (lightTextBox.Foreground as SolidColorBrush).Color);

                TextBlock darkTextBox = (TextBlock)ControlsTestPage.Instance.FindName("DarkThemeText");
                Assert.IsNotNull(darkTextBox);
                Assert.AreEqual("Dark", darkTextBox.Text);
                Assert.AreEqual(Colors.White, (darkTextBox.Foreground as SolidColorBrush).Color);
            }
        }
    }
}
