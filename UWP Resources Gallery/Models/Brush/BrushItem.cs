using System.Linq;

namespace UWPResourcesGallery.Models.Brush
{
    public class BrushItem : IFilterable
    {
        public string Key { get; private set; }

        public string Name { get; private set; }

        public string LightHEX { get; private set; }
        public string DarkHEX { get; private set; }

        public BrushItem(string key, string name, string lightHEX, string darkHEX)
        {
            this.Key = key;
            this.Name = name;
            this.LightHEX = lightHEX;
            this.DarkHEX = darkHEX;
        }

        public bool FitsFilter(string[] filter)
        {
            return filter.All(entry =>
                Key.Contains(entry,System.StringComparison.CurrentCultureIgnoreCase)
                || Name.Contains(entry,System.StringComparison.CurrentCultureIgnoreCase)
                || LightHEX.Contains(entry,System.StringComparison.CurrentCultureIgnoreCase)
                || DarkHEX.Contains(entry,System.StringComparison.CurrentCultureIgnoreCase)
            );
        }
    }
}
