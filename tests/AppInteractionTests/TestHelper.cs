using OpenQA.Selenium;
using OpenQA.Selenium.Appium.MultiTouch;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Text;

namespace AppInteractionTests
{
    class TestHelper
    {

        public static ICollection<WindowsElement> GetElementsOfType(string elementType)
        {
            return TestRunInitializer.Session.FindElementsByTagName(elementType);
        }

        public static List<WindowsElement> GetElementsOfTypeWithContent(string elementType, string content)
        {
            return GetItemsWithContent(GetElementsOfType(elementType), content);
        }

        public static List<WindowsElement> GetItemsWithContent(ICollection<WindowsElement> elements, string content)
        {
            var elementsToReturn = new List<WindowsElement>();
            foreach (var element in elements)
            {
                if (element.Text.Contains(content, StringComparison.OrdinalIgnoreCase))
                {
                    elementsToReturn.Add(element);
                    continue;
                }
                // Check children if we did not find it in the items name
                var children = element.FindElementsByTagName("Text");
                foreach (var child in children)
                {
                    if (child.Text.Contains(content, StringComparison.OrdinalIgnoreCase))
                    {
                        elementsToReturn.Add(element);
                        continue;
                    }
                }
            }
            return elementsToReturn;
        }

        public static void WaitMilli(int milliSeconds)
        {
            System.Threading.Thread.Sleep(milliSeconds);
        }

        public static void InvokeButton(string text,int buttonIndex)
        {
            List<WindowsElement> buttons = GetElementsOfTypeWithContent("Button", text);

            buttons[buttonIndex].Click();
        }

        public static void NavigateToPage(string name)
        {
            var container = TestRunInitializer.Session.FindElementByName("Mainnavigation");
            container.FindElementByName(name).Click();
        }

        public static string CurrentPageInNavigation()
        {
            var container = TestRunInitializer.Session.FindElementByName("Mainnavigation");
            var listItems = container.FindElementsByTagName("ListItem");
            foreach(var item in listItems)
            {
                if (item.Selected)
                {
                    return item.Text;
                }
            }
            return "";
        }
    }
}
