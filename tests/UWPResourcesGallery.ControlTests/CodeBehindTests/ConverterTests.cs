using Microsoft.VisualStudio.TestTools.UnitTesting;
using UWPResourcesGallery.Common;
using Windows.UI.Xaml;

namespace UWPResourcesGallery.ControlTests.CodeBehindTests
{
    [TestClass]
    public class ConverterTests
    {
        [TestMethod]
        public void BoolToVisibilityConverterTest()
        {
            BoolToVisibilityConverter converter = new BoolToVisibilityConverter();

            Assert.AreEqual(Visibility.Collapsed, converter.Convert(false, null, null, null));
            Assert.AreEqual(Visibility.Visible, converter.Convert(true, null, null, null));
        }


        [TestMethod]
        public void StringValueToVisibilityConverterTest()
        {
            StringValueToVisibilityConverter converter = new StringValueToVisibilityConverter();

            Assert.AreEqual(Visibility.Collapsed, converter.Convert("", null, null, null));
            Assert.AreEqual(Visibility.Collapsed, converter.Convert(null, null, null, null));
            Assert.AreEqual(Visibility.Visible, converter.Convert("This is text", null, null, null));
        }

    }
}
