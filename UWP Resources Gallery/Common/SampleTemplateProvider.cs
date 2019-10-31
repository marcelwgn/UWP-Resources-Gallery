using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWPResourcesGallery.Common
{
    static class SampleTemplateProvider
    {
        private const string FontIconWithGlyph =            
            "<FontIcon Glyph=\"${}\" />";

        public static string GetFontIconCodeFromGlyph(string glyph)
        {
            return FontIconWithGlyph.Replace("${}",glyph);
        }

    }
}
