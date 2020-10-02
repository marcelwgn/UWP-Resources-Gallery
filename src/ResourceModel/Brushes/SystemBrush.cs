using System.Linq;
using Windows.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Markup;
using Windows.UI.Xaml.Media;

namespace UWPResourcesGallery.Model.Brushes
{
    public class SystemBrush : IFilterable
    {
        public string Key { get; private set; }
        public string Name { get; private set; }
        public string UIAName => "System brush " + Key;
        public string XAMLDefinition { get; private set; }
        public Brush LightThemeBrush { get; private set; }
        public string LightThemeHexCode { get; private set; }
        public Brush DarkThemeBrush { get; private set; }
        public string DarkThemeHexCode { get; private set; }
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
            LightThemeBrush = grid.Background as Brush;

            // Set hex code
            LightThemeHexCode = "";
            Color lightColor = new Color();

            if (LightThemeBrush is SolidColorBrush lightBrush)
            {
                lightColor = lightBrush.Color;
                
            }
            else if (LightThemeBrush is AcrylicBrush lightAcrylicBrush)
            {
                lightColor = lightAcrylicBrush.TintColor;
            }

            int lastIndex = 1;
            LightThemeHexCode = "#";
            for (int curIndex = 0; curIndex < 4; curIndex++)
            {
                LightThemeHexCode += lightColor.ToString().Substring(lastIndex, 2);
                if (curIndex < 3)
                {
                    LightThemeHexCode += " ";
                }
                lastIndex += 2;
            }

            // Dark theme brush
            grid = XamlReader.Load(@"<Border xmlns='http://schemas.microsoft.com/winfx/2006/xaml/presentation'
                    RequestedTheme='Dark'
                    Background='{ThemeResource " + Key + "}'></Border>") as Border;
            DarkThemeBrush = grid.Background as Brush;

            // Set hex code
            DarkThemeHexCode = "";
            Color darkColor = new Color();

            if (DarkThemeBrush is SolidColorBrush darkBrush)
            {
                darkColor = darkBrush.Color;
            }
            else if(DarkThemeBrush is AcrylicBrush darkAcrylicBrush)
            {
                darkColor = darkAcrylicBrush.TintColor;
            }

            lastIndex = 1;
            DarkThemeHexCode = "#";
            for (int curIndex = 0; curIndex < 4; curIndex++)
            {
                DarkThemeHexCode += darkColor.ToString().Substring(lastIndex, 2);
                if (curIndex < 3)
                {
                    DarkThemeHexCode += " ";
                }
                lastIndex += 2;
            }

            XAMLDefinition = xamlDefinition;
        }

        public bool FitsFilter(string[] filter)
        {
            return filter.All(entry =>
                Key.Contains(entry, System.StringComparison.CurrentCultureIgnoreCase)
                || Name.Contains(entry, System.StringComparison.CurrentCultureIgnoreCase)
                || XAMLDefinition.Contains(entry, System.StringComparison.CurrentCultureIgnoreCase)
                || ThemeResourceString.Contains(entry, System.StringComparison.CurrentCultureIgnoreCase)
                || LightThemeHexCode.Replace(" ", "",System.StringComparison.InvariantCulture)
                    .Contains(entry, System.StringComparison.CurrentCultureIgnoreCase)
                || DarkThemeHexCode.Replace(" ", "", System.StringComparison.InvariantCulture)
                    .Contains(entry, System.StringComparison.CurrentCultureIgnoreCase)
            );
        }
    }
}
