using System.Linq;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Markup;
using Windows.UI.Xaml.Media;

namespace UWPResourcesGallery.Model.Colors
{
    public class SystemColor : IFilterable
    {
        public string Key { get; private set; }

        public string Name { get; private set; }

        public string UIAName => "System color " + Name;

        public string LightHex { get; private set; }
        public string DarkHex { get; private set; }

        public SolidColorBrush LightThemeBrush { get; private set; }
        public SolidColorBrush DarkThemeBrush { get; private set; }

        public string ThemeResourceString => "{ThemeResource " + Key + "}";

        public SystemColor(string key, string name, string lightHEX, string darkHEX)
        {
            Key = key;
            Name = name;
            LightHex = lightHEX;
            DarkHex = darkHEX;

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
        }

        public bool FitsFilter(string[] filter)
        {
            return filter.All(entry =>
                Key.Contains(entry, System.StringComparison.CurrentCultureIgnoreCase)
                || Name.Contains(entry, System.StringComparison.CurrentCultureIgnoreCase)
                || LightHex.Contains(entry, System.StringComparison.CurrentCultureIgnoreCase)
                || DarkHex.Contains(entry, System.StringComparison.CurrentCultureIgnoreCase)
                || ThemeResourceString.Contains(entry, System.StringComparison.CurrentCultureIgnoreCase)
            );
        }

    }
}
