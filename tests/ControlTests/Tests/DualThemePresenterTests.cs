
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UnitTesting.AppContainer;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace ControlTests
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

            var darkTextBox = (TextBlock)ControlsTestPage.Instance.FindName("DarkThemeText");
            Assert.IsNotNull(darkTextBox);
            Assert.AreEqual("Dark", darkTextBox.Text);
        }
    }
}
