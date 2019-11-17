
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UnitTesting.AppContainer;
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
