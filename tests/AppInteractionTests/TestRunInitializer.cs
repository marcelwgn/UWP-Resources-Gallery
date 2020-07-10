using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Diagnostics;
using System.Threading;

namespace AppInteractionTests
{
    internal class TestRunInitializer
    {
        private const string WindowsApplicationDriverUrl = "http://127.0.0.1:4723";
#if DEBUG
        private const string AppUIBasicAppId = "UWP-Resourcess-Gallery-Debug_d9qrpd3r6ja58!App";
#else
        private const string AppUIBasicAppId = "UWP-Resourcess-Gallery_d9qrpd3r6ja58!App";
#endif

        private static WindowsDriver<WindowsElement> _session;
        public static WindowsDriver<WindowsElement> Session
        {
            get
            {
                if (_session == null)
                {
                    CreateSession();
                }
                return _session;
            }
        }

        [AssemblyInitialize]
        private static void CreateSession()
        {
            if (_session == null)
            {
                AppiumOptions appiumOptions = new AppiumOptions();
                appiumOptions.AddAdditionalCapability("app", AppUIBasicAppId);
                appiumOptions.AddAdditionalCapability("deviceName", "WindowsPC");
                try
                {
                    _session = new WindowsDriver<WindowsElement>(new Uri(WindowsApplicationDriverUrl), appiumOptions);
                }
                catch (OpenQA.Selenium.WebDriverException) { }
                Thread.Sleep(3000);
                if (_session == null)
                {
                    // WinAppDriver is probably not running, so lets start it!
                    Process.Start(@"C:\Program Files (x86)\Windows Application Driver\WinAppDriver.exe");

                    Thread.Sleep(10000);
                    _session = new WindowsDriver<WindowsElement>(new Uri(WindowsApplicationDriverUrl), appiumOptions);
                }
                Assert.IsNotNull(_session);
                Assert.IsNotNull(_session.SessionId);

                // Dismiss the disclaimer window that may pop up on the very first application launch
                // If the disclaimer is not find, this throws an exception, so lets catch that
                try
                {
                    _session.FindElementByName("Disclaimer").FindElementByName("Accept").Click();
                }
                catch (OpenQA.Selenium.WebDriverException) { }

                // Wait if something is still animating in the visual tree
                _session.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
                _session.Manage().Window.Maximize();
            }
        }

        [AssemblyCleanup()]
        public static void TestRunTearDown()
        {
            TearDown();
        }

        public static void TearDown()
        {
            if (_session != null)
            {
                _session.Quit();
                _session = null;
            }
        }
    }
}
