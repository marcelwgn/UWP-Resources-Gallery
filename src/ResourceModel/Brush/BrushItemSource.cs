using System.Threading.Tasks;
using Windows.Data.Json;

namespace UWPResourcesGallery.Model.Brush
{
    public class BrushItemSource : GenericItemsSource<BrushItem>
    {
        public static void LoadBrushList()
        {
            var file = GetJSONFile("/ResourceModel/Assets/SystemColors.json");
            var list = file["brushes"].GetArray();
            foreach (JsonValue entry in list)
            {
                JsonObject entryObject = entry.GetObject();
                var brush = new BrushItem(
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
