using Windows.UI.Xaml.Controls;

namespace UWPResourcesGallery.Common
{
    internal static class SampleTemplateProvider
    {
        public static string GetXAMLFontIconCodeFromGlyph(string glyph)
        {
            return "<FontIcon Glyph=\"" + glyph + "\" />";
        }
        public static string GetCSFontIconCodeFromGlyph(string glyph)
        {
            return "FontIcon icon = new FontIcon();" +
                "\nicon.Glyph = \"\\u" + glyph.Substring(3, 4) + "\";";
        }

        public static string GetXAMLButtonIconFromGlyph(string glyph)
        {
            return "<Button>" +
                "\n  " + GetXAMLFontIconCodeFromGlyph(glyph) +
                "\n</Button>";
        }
        public static string GetCSButtonIconFromGlyph(string glyph)
        {
            return "Button button = new Button();" +
                "\nbutton.Content = new FontIcon();" +
                "\n(button.Content as FontIcon).Glyph = \"\\u" + glyph.Substring(3, 4) + "\";";
        }

        internal static string GetXAMLSymbolIconCodeFromGlyph(string name)
        {
            return "<SymbolIcon Symbol=\"" + name + "\" />";
        }
        public static string GetCSSymbolIconCodeFromGlyph(string name)
        {
            return "SymbolIcon icon = new SymbolIcon();" +
                "\nicon.Symbol = Symbol." + name + ";";
        }

        public static string GetXAMLButtonIconFromSymbolName(string name)
        {
            return "<Button>" +
                "\n  " + GetXAMLSymbolIconCodeFromGlyph(name) +
                "\n</Button>";
        }
        public static string GetCSButtonIconFromSymbolName(string glyph)
        {
            return "Button button = new Button();" +
                "\nbutton.Content = new SymbolIcon();" +
                "\n(button.Content as SymbolIcon).Symbol = Symbol." + glyph + ";";
        }

        internal static string GetXAMLCustomizedFontIconCode(string glyph, string color, string size)
        {
            return $"<FontIcon Glyph=\"{glyph}\"\n     Foreground=\"{color}\"\n     FontSize=\"{size}\"/>";
        }
    }
}
