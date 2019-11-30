using System.Threading.Tasks;
using Windows.Data.Json;

namespace UWPResourcesGallery.Model.Brush
{
    public class SystemColorsItemSource : GenericItemsSource<SystemColor>
    {
        public static void LoadSystemColors()
        {
            var file = GetJSONFile("/ResourceModel/Assets/SystemColors.json");
            var list = file["colors"].GetArray();
            foreach (JsonValue entry in list)
            {
                JsonObject entryObject = entry.GetObject();
                var brush = new SystemColor(
                    entryObject["key"].GetString(),
                    entryObject["name"].GetString(),
                    entryObject["lightHex"].GetString(),
                    entryObject["darkHex"].GetString()
                );
                Items.Add(brush);
            }
        }
    }
}
