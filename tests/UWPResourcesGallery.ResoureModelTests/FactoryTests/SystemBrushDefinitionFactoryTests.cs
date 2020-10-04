using Microsoft.VisualStudio.TestTools.UnitTesting;
using UWPResourcesGallery.ResourceModel.Brushes;

namespace UWPResourcesGallery.ResoureModelTests.FactoryTests
{
    [TestClass]
    public class SystemBrushDefinitionFactoryTests
    {

        [TestMethod]
        public void SolidColorBrushDefinitionsAreCorrect()
        {
            Assert.AreEqual(
                "<SolidColorBrush\n  x:Key=\"MyKey\"\n  Color=\"{MyColor}\" />",
                SystemBrushDefinitionFactory.SolidColorBrushDefinition("MyKey", "{MyColor}"));

            Assert.AreEqual(
                "<SolidColorBrush\n  x:Key=\"MyKey\"\n  Color=\"{MyColor}\" Opacity=\"0.4\" />",
                SystemBrushDefinitionFactory.SolidColorBrushDefinition("MyKey", "{MyColor}", 0.4));
        }


        [TestMethod]
        public void AcrylicBrushDefinitionsAreCorrect()
        {
            Assert.AreEqual(
                "<AcrylicBrush\n  x:Key=\"MyKey\"\n  BackgroundSource=\"MyBackgroundSource\"\n  " +
                "TintColor=\"MyTintColor\"\n  TintOpacity=\"0.8\"\n  FallBackColor=\"MyFallBackColor\" />",
                SystemBrushDefinitionFactory.AcrylicBrushDefinition("MyKey", "MyBackgroundSource", "MyTintColor", 0.8, "MyFallBackColor"));
        }

        [TestMethod]
        public void StaticResourceDefinitionsAreCorrect()
        {
            Assert.AreEqual(
                "<StaticResource\n  x:Key=\"MyKey\"\n  ResourceKey=\"MyResourceKey\" />",
                SystemBrushDefinitionFactory.StaticResourceDefinition("MyKey", "MyResourceKey"));
        }
    }
}
