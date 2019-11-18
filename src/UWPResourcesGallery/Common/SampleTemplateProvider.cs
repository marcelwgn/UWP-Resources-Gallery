namespace UWPResourcesGallery.Common
{
    static class SampleTemplateProvider
    {
        private const string FontIconWithGlyph =
            "<FontIcon Glyph=\"${Glyph}\"/>";

        private const string SymbolIconWithGlyph =
            "<SymbolIcon Symbol=\"${Symbol}\"/>";

        public static string GetFontIconCodeFromGlyph(string glyph)
        {
            return FontIconWithGlyph.Replace("${Glyph}", glyph,System.StringComparison.Ordinal);
        }

        internal static string GetSymbolIconCodeFromGlyph(string name)
        {
            return SymbolIconWithGlyph.Replace("${Symbol}", name, System.StringComparison.Ordinal);
        }

        internal static string AddColorToSymbolIcon(string symbolIconString, string color)
        {
            return symbolIconString.Replace("/>", "Color:\"" + color + "\" />", System.StringComparison.Ordinal);
        }
    }
}
