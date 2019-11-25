namespace UWPResourcesGallery.Common
{
    static class SampleTemplateProvider
    {
        private const string FontIconWithGlyph =
            "<FontIcon Glyph=\"${Glyph}\"/>";

        private const string FontIconWithGlyphColorSize =
            "<FontIcon Glyph=\"${Glyph}\" ForeGround=\"${ForeGround}\" FontSize=\"${FontSize}\"/>";

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

        internal static string GetCustomizedFontIconCode(string glyph,string color,string size)
        {
            return $"<FontIcon Glyph=\"{glyph}\"\n     ForeGround=\"{color}\"\n     FontSize=\"{size}\"/>";
        }
    }
}
