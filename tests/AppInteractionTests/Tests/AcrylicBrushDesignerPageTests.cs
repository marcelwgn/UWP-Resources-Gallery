using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppInteractionTests.Tests
{
    [TestClass]
    public class AcrylicBrushDesignerPageTests : BasePageTest
    {
        public override string NavigationName => "AcrylicBrush designer";

        [TestMethod]
        public void UpdatesSampleCorrectly()
        {
            var luminositySlider = TestRunInitializer.Session.FindElementByName("Tint luminosity opacity slider");
            luminositySlider.Click();
            for (int i = 0; i < 50; i++)
            {
                luminositySlider.SendKeys(Keys.Right);
            }
            
            var opacitySlider = TestRunInitializer.Session.FindElementByName("Tint opacity slider");
            opacitySlider.Click();
            for (int i = 0; i < 50; i++)
            {
                opacitySlider.SendKeys(Keys.Right);
            }

            Assert.IsTrue(Math.Abs(1 - double.Parse(luminositySlider.GetAttribute("RangeValue.Value"))) < 0.01);
            Assert.IsTrue(Math.Abs(1 - double.Parse(opacitySlider.GetAttribute("RangeValue.Value"))) < 0.01);


            var codeSample = TestRunInitializer.Session.FindElementByName("AcrylicBrush source code");
            var richEditBlock = codeSample.FindElementByAccessibilityId("CodeSampleCode");


            var expected = "<AcrylicBrush Color=\"#FF808080\"\r\n    TintOpacity=\"1\"\r\n    contract8Present:TintLuminosityOpacity=\"1\"/>\r\n";
            Assert.AreEqual(expected, richEditBlock.Text);
        }
    }
}
