using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppInteractionTests.Tests
{
    [TestClass]
    public class StartPageTests : BasePageTest
    {
        public override string NavigationName => "Start";

        [TestMethod]
        public void RendersButtonsAndText()
        {
            // Verifying start page text
            Assert.AreEqual(1, TestHelper.GetElementsOfTypeWithContent("Text", "Welcome to").Count);
            Assert.AreEqual(1, TestHelper.GetElementsOfTypeWithContent("Text", "This app contains").Count);

            // Verifying buttons exist
            Assert.AreEqual(1, TestHelper.GetElementsOfTypeWithContent("Button", "Icon list").Count);
            Assert.AreEqual(1, TestHelper.GetElementsOfTypeWithContent("Button", "Systemcolors").Count);
        }

        [TestMethod]
        public void VerifyIconNavigation()
        {
            TestHelper.InvokeButton("Icon list", 0);

            Assert.AreEqual("Icons", TestHelper.CurrentPageInNavigation());
        }

        [TestMethod]
        public void VerifySystemColorsNavigation()
        {
            TestHelper.InvokeButton("Systemcolors", 0);

            Assert.AreEqual("Systemcolors", TestHelper.CurrentPageInNavigation());
        }
    }
}
