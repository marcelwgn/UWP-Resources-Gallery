using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace AppInteractionTests
{
    class TestHelper
    {

        public static List<WindowsElement> GetElementsOfTypeWithContent(string elementType, string content)
        {
            var elementsToReturn = new List<WindowsElement>();
            var elements = TestRunInitializer.Session.FindElementsByTagName(elementType);
            foreach(var element in elements)
            {
                if (element.Text.Contains(content, StringComparison.OrdinalIgnoreCase))
                {
                    elementsToReturn.Add(element);
                    continue;
                }

                // Did not have the right text
                // Skip if text exists,continue if children define content
                if (!string.IsNullOrEmpty(element.Text))
                {
                    continue;
                }

                // Check children
                var children = element.FindElementsByTagName("Text");
                foreach(var child in children)
                {
                    if (child.Text.Contains(content,StringComparison.OrdinalIgnoreCase))
                    {
                        elementsToReturn.Add(element);
                        continue;
                    }
                }
            }
            return elementsToReturn;
        }

        public static void InvokeButton(string text,int buttonIndex)
        {
            List<WindowsElement> buttons = GetElementsOfTypeWithContent("Button", text);

            buttons[buttonIndex].Click();
        }

        public static string CurrentPageInNavigation()
        {
            var listItems = TestRunInitializer.Session.FindElementsByTagName("ListItem");
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
