namespace UWPResourcesGallery.Model.Brushes
{
    public static class SystemBrushDefinitionFactory
    {
        public static string SolidColorBrushDefinition(string key, string color)
        {
            return string.Concat("<SolidColorBrush\n  x:Key=\"", key,
                "\"\n  Color=\"", color, "\" />");
        }

        public static string SolidColorBrushDefinition(string key, string color, double opacity)
        {
            return string.Concat("<SolidColorBrush\n  x:Key=\"", key,
                "\"\n  Color=\"", color,
                "\" Opacity=\"", opacity, "\" />");
        }

        public static string AcrylicBrushDefinition(string key, string backgroundSource, string tintColor, double tintOpacity, string fallBackColor)
        {
            return string.Concat("<AcrylicBrush\n  x:Key=\"", key,
                "\"\n  BackgroundSource=\"", backgroundSource,
                "\"\n  TintColor=\"", tintColor,
                "\"\n  TintOpacity=\"", tintOpacity,
                "\"\n  FallBackColor=\"", fallBackColor, "\" />");
        }

        public static string StaticResourceDefinition(string key, string resourceKey)
        {
            return string.Concat("<StaticResource\n  x:Key=\"", key,
                "\"\n  ResourceKey=\"", resourceKey, "\" />");
        }

    }
}
