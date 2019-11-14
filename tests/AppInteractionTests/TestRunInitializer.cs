using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Diagnostics;
using System.Threading;

namespace ControlTests
{
    class TestRunInitializer
    {
        private const string WindowsApplicationDriverUrl = "http://127.0.0.1:4723";
        private const string AppUIBasicAppId = "UWP-Resourcess-Gallery_d9qrpd3r6ja58!App";
        public static WindowsDriver<WindowsElement> Session = null;
        
        static TestRunInitializer()
        {
            if (Session == null)
            {
                Process.Start(@"C:\Program Files (x86)\Windows Application Driver\WinAppDriver.exe");
                var appiumOptions = new AppiumOptions();
                appiumOptions.AddAdditionalCapability("app", AppUIBasicAppId);
                
                try
                {
                    Session = new WindowsDriver<WindowsElement>(new Uri(WindowsApplicationDriverUrl), appiumOptions);
                }
                catch
                {
                }
                Thread.Sleep(5000);
                if (Session == null)
                {
                    // WinAppDriver is probably not running, so lets start it!
                    Thread.Sleep(10000);
                    Session = new WindowsDriver<WindowsElement>(new Uri(WindowsApplicationDriverUrl), appiumOptions);
                }
                Assert.IsNotNull(Session);
                Assert.IsNotNull(Session.SessionId);
                // Dismiss the disclaimer window that may pop up on the very first application launch
                try
                {
                    Session.FindElementByName("Disclaimer").FindElementByName("Accept").Click();
                }
                catch { }
            }
            Session.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        public static void TearDown()
        {
            if (Session != null)
            {
                Session.Quit();
                Session = null;
            }
        }
    }
}
