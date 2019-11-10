using System.Linq;

namespace UWPResourcesGallery.Model.Brush
{
    public class BrushItem : IFilterable
    {
        public string Key { get; private set; }

        public string Name { get; private set; }

        public string LightHex { get; private set; }
        public string DarkHex { get; private set; }

        public BrushItem(string key, string name, string lightHEX, string darkHEX)
        {
            Key = key;
            Name = name;
            LightHex = lightHEX;
            DarkHex = darkHEX;
        }

        public bool FitsFilter(string[] filter)
        {
            return filter.All(entry =>
                Key.Contains(entry, System.StringComparison.CurrentCultureIgnoreCase)
                || Name.Contains(entry, System.StringComparison.CurrentCultureIgnoreCase)
                || LightHex.Contains(entry, System.StringComparison.CurrentCultureIgnoreCase)
                || DarkHex.Contains(entry, System.StringComparison.CurrentCultureIgnoreCase)
            );
        }
    }
}
