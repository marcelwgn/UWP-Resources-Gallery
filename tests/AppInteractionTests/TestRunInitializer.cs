using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Diagnostics;
using System.Threading;

namespace AppInteractionTests
{
    class TestRunInitializer
    {
        private const string WindowsApplicationDriverUrl = "http://127.0.0.1:4723";
        private const string AppUIBasicAppId = "UWP-Resourcess-Gallery_d9qrpd3r6ja58!App";

        private static WindowsDriver<WindowsElement> _session;
        public static WindowsDriver<WindowsElement> Session {
            get
            {
                if(_session == null)
                {
                    CreateSession();
                }
                return _session;
            }
        }

        private static void CreateSession()
        {
            if (_session == null)
            {
                var appiumOptions = new AppiumOptions();
                appiumOptions.AddAdditionalCapability("app", AppUIBasicAppId);

                _session = new WindowsDriver<WindowsElement>(new Uri(WindowsApplicationDriverUrl), appiumOptions);
                Thread.Sleep(5000);
                if (Session == null)
                {
                    // WinAppDriver is probably not running, so lets start it!
                    Process.Start(@"C:\Program Files (x86)\Windows Application Driver\WinAppDriver.exe");

                    Thread.Sleep(10000);
                    _session = new WindowsDriver<WindowsElement>(new Uri(WindowsApplicationDriverUrl), appiumOptions);
                }
                Assert.IsNotNull(Session);
                Assert.IsNotNull(Session.SessionId);

                // Dismiss the disclaimer window that may pop up on the very first application launch
                // If the disclaimer is not find, this throws an exception, so lets catch that
                try
                {
                    Session.FindElementByName("Disclaimer").FindElementByName("Accept").Click();
                }
                catch (OpenQA.Selenium.WebDriverException) { }

                // Wait if something is still animating in the visual tree
                Session.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            }
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
