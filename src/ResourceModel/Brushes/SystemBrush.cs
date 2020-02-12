using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Markup;
using Windows.UI.Xaml.Media;

namespace UWPResourcesGallery.Model.Brushes
{
    public class SystemBrush : IFilterable
    {
        public string Key { get; private set; }
        public string Name { get; private set; }
        public string XAMLDefinition { get; private set; }
        public Brush LightThemeBrush { get; private set; }
        public Brush DarkThemeBrush { get; private set; }
        public string ThemeResourceString => "{ThemeResource " + Key + "}";

        public SystemBrush(string key, string name, string xamlDefinition)
        {
            Key = key;
            Name = name;

            // Generating SolidColorBrush from XAML code!
            // Light theme brush
            Border grid = XamlReader.Load(@"<Border xmlns='http://schemas.microsoft.com/winfx/2006/xaml/presentation'
                    RequestedTheme='Light'
                    Background='{ThemeResource " + Key + "}'></Border>") as Border;
            LightThemeBrush = grid.Background as SolidColorBrush;

            // Dark theme brush
            grid = XamlReader.Load(@"<Border xmlns='http://schemas.microsoft.com/winfx/2006/xaml/presentation'
                    RequestedTheme='Dark'
                    Background='{ThemeResource " + Key + "}'></Border>") as Border;
            DarkThemeBrush = grid.Background as SolidColorBrush;

            XAMLDefinition = xamlDefinition;
        }

        public bool FitsFilter(string[] filter)
        {
            return filter.All(entry =>
                Key.Contains(entry, System.StringComparison.CurrentCultureIgnoreCase)
                || Name.Contains(entry, System.StringComparison.CurrentCultureIgnoreCase)
                || XAMLDefinition.Contains(entry, System.StringComparison.CurrentCultureIgnoreCase)
                || ThemeResourceString.Contains(entry, System.StringComparison.CurrentCultureIgnoreCase)
            );
        }
    }
}
