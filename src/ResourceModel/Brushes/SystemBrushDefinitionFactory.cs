using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWPResourcesGallery.Model.Brushes
{
    public static class SystemBrushDefinitionFactory
    {
        public static string SolidColorBrushDefinition(string key, string color)
        {
            return string.Concat("<SolidColorBrush x:Key=\"", key,
                "\" Color=\"", color, "\" />");
        }

        public static string SolidColorBrushDefinition(string key, string color, double opacity)
        {
            return string.Concat("<SolidColorBrush x:Key=\"", key,
                "\" Color=\"", color,
                "\" Opacity=\"", opacity, "\" />");
        }

        public static string AcrylicBrushDefinition(string key, string backgroundSource, string tintColor, double tintOpacity, string fallBackColor)
        {
            return string.Concat("<AcrylicBrush x:Key=\"", key,
                "\" BackgroundSource=\"", backgroundSource,
                "\" TintColor=\"", tintColor,
                "\" TintOpacity=\"", tintOpacity,
                "\" FallBackColor=\"", fallBackColor, "\" />");
        }

        public static string StaticResourceDefinition(string key, string resourceKey)
        {
            return string.Concat("<StaticResource x:Key=\"", key,
                "\" ResourceKey=\"", resourceKey, "\" />");
        }

    }
}
