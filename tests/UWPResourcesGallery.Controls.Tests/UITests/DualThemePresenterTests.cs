
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UnitTesting.AppContainer;
using System;
using UWPResourcesGallery.Controls.Common;
using Windows.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace UWPResourcesGallery.Controls.Tests.UITests
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
                Assert.AreEqual(Colors.Black.R, (lightTextBox.Foreground as SolidColorBrush).Color.R);
                Assert.AreEqual(Colors.Black.G, (lightTextBox.Foreground as SolidColorBrush).Color.G);
                Assert.AreEqual(Colors.Black.B, (lightTextBox.Foreground as SolidColorBrush).Color.B);

                TextBlock darkTextBox = (TextBlock)ControlsTestPage.Instance.FindName("DarkThemeText");
                Assert.IsNotNull(darkTextBox);
                Assert.AreEqual("Dark", darkTextBox.Text);
                Assert.AreEqual(Colors.White.R, (darkTextBox.Foreground as SolidColorBrush).Color.R);
                Assert.AreEqual(Colors.White.G, (darkTextBox.Foreground as SolidColorBrush).Color.G);
                Assert.AreEqual(Colors.White.B, (darkTextBox.Foreground as SolidColorBrush).Color.B);
            }
        }
    }
}
