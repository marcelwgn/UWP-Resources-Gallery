using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWPResourcesGallery.Model.Brushes;

namespace ResoureModelTests
{
    [TestClass]
    public class SystemBrushDefinitionFactoryTests
    {

        [TestMethod]
        public void SolidColorBrushDefinitionsAreCorrect()
        {
            Assert.AreEqual(
                "<SolidColorBrush x:Key=\"MyKey\" Color=\"{MyColor}\" />",
                SystemBrushDefinitionFactory.SolidColorBrushDefinition("MyKey", "{MyColor}"));

            Assert.AreEqual(
                "<SolidColorBrush x:Key=\"MyKey\" Color=\"{MyColor}\" Opacity=\"0.4\" />",
                SystemBrushDefinitionFactory.SolidColorBrushDefinition("MyKey", "{MyColor}", 0.4));
        }


        [TestMethod]
        public void AcrylicBrushDefinitionsAreCorrect()
        {
            Assert.AreEqual(
                "<AcrylicBrush x:Key=\"MyKey\" BackgroundSource=\"MyBackgroundSource\" " +
                "TintColor=\"MyTintColor\" TintOpacity=\"0.8\" FallBackColor=\"MyFallBackColor\" />",
                SystemBrushDefinitionFactory.AcrylicBrushDefinition("MyKey", "MyBackgroundSource", "MyTintColor", 0.8, "MyFallBackColor"));
        }

        [TestMethod]
        public void StaticResourceDefinitionsAreCorrect()
        {
            Assert.AreEqual(
                "<StaticResource x:Key=\"MyKey\" ResourceKey=\"MyResourceKey\" />",
                SystemBrushDefinitionFactory.StaticResourceDefinition("MyKey", "MyResourceKey"));
        }
    }
}
