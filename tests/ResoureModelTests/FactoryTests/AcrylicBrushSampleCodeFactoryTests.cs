using Microsoft.VisualStudio.TestTools.UnitTesting;
using UWPResourcesGallery.Model;
using Windows.UI;

namespace ResoureModelTests.FactoryTests
{
    [TestClass]
    public class AcrylicBrushSampleCodeFactoryTests
    {
        [TestMethod]
        public void SolidColorBrushDefinitionsAreCorrect()
        {
            Assert.AreEqual(
                "<AcrylicBrush Color=\"#FF000000\"\n    TintOpacity=\"0\"\n    contract8Present:TintLuminosityOpacity=\"0\"/>",
                AcrylicBrushSampleCodeFactory.GetAcrylicBrushXAMLCode(Colors.Black, 0, 0));

            Assert.AreEqual(
                "<AcrylicBrush Color=\"#FFFFFFFF\"\n    TintOpacity=\"0\"\n    contract8Present:TintLuminosityOpacity=\"0\"/>",
                AcrylicBrushSampleCodeFactory.GetAcrylicBrushXAMLCode(Colors.White, 0, 0));

            Assert.AreEqual(
                "<AcrylicBrush Color=\"#FFFFFFFF\"\n    TintOpacity=\"0\"\n    contract8Present:TintLuminosityOpacity=\"1\"/>",
                AcrylicBrushSampleCodeFactory.GetAcrylicBrushXAMLCode(Colors.White, 0, 1));

            Assert.AreEqual(
                "<AcrylicBrush Color=\"#FFFFFFFF\"\n    TintOpacity=\"1\"\n    contract8Present:TintLuminosityOpacity=\"0\"/>",

                AcrylicBrushSampleCodeFactory.GetAcrylicBrushXAMLCode(Colors.White, 1, 0));
            Assert.AreEqual(
                "<AcrylicBrush Color=\"#FFFFFFFF\"\n    TintOpacity=\"0\"\n    contract8Present:TintLuminosityOpacity=\"0.3\"/>",
                AcrylicBrushSampleCodeFactory.GetAcrylicBrushXAMLCode(Colors.White, 0, 0.30000000004));

            Assert.AreEqual(
                "<AcrylicBrush Color=\"#FFFFFFFF\"\n    TintOpacity=\"0.3\"\n    contract8Present:TintLuminosityOpacity=\"0\"/>",
                AcrylicBrushSampleCodeFactory.GetAcrylicBrushXAMLCode(Colors.White, 0.30000000004, 0));
        }
    }
}
