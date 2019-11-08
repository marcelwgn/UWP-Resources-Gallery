using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWPResourcesGallery.Common
{
    static class SampleTemplateProvider
    {
        private const string XAMLCore = "<${Type}/>";


        private const string FontIconWithGlyph =            
            "<FontIcon Glyph=\"${Glyph}\"/>";

        private const string SymbolIconWithGlyph =
            "<SymbolIcon Symbol=\"${Symbol}\"/>";

        public static string GetFontIconCodeFromGlyph(string glyph)
        {
            return FontIconWithGlyph.Replace("${Glyph}",glyph);
        }

        internal static string GetSymbolIconCodeFromGlyph(string name)
        {
            return SymbolIconWithGlyph.Replace("${Symbol}", name);
        }
    }
}
