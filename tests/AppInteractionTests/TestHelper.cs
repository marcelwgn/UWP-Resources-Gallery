using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;

namespace AppInteractionTests
{
    internal class TestHelper
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
            List<WindowsElement> elementsToReturn = new List<WindowsElement>();
            foreach (WindowsElement element in elements)
            {
                if (element.Text.Contains(content, StringComparison.OrdinalIgnoreCase))
                {
                    elementsToReturn.Add(element);
                    continue;
                }
                // Check children if we did not find it in the items name
                System.Collections.ObjectModel.ReadOnlyCollection<OpenQA.Selenium.Appium.AppiumWebElement> children = element.FindElementsByTagName("Text");
                foreach (OpenQA.Selenium.Appium.AppiumWebElement child in children)
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

        public static void InvokeButton(string text, int buttonIndex)
        {
            List<WindowsElement> buttons = GetElementsOfTypeWithContent("Button", text);

            buttons[buttonIndex].Click();
        }

        public static void NavigateToPage(string name)
        {
            WindowsElement container = TestRunInitializer.Session.FindElementByName("Mainnavigation");
            container.FindElementByName(name).Click();
        }

        public static string CurrentPageInNavigation()
        {
            WindowsElement container = TestRunInitializer.Session.FindElementByName("Mainnavigation");
            System.Collections.ObjectModel.ReadOnlyCollection<OpenQA.Selenium.Appium.AppiumWebElement> listItems = container.FindElementsByTagName("ListItem");
            foreach (OpenQA.Selenium.Appium.AppiumWebElement item in listItems)
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
