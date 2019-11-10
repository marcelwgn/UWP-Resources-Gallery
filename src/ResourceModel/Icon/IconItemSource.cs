using System.Threading.Tasks;
using Windows.Data.Json;

namespace UWPResourcesGallery.Model.Icon
{
    public class IconItemSource : GenericItemsSource<IconItem>
    {

        public static async Task LoadIconsList()
        {
            var file = await GetJSONFile("IconList.json");
            var list = file["icons"].GetArray();
            lock (Items)
            {
                foreach (JsonValue entry in list)
                {
                    JsonObject entryObject = entry.GetObject();
                    IconItem icon = new IconItem(
                            entryObject["code"].GetString(),
                            entryObject["name"].GetString()
                        );
                    Items.Add(icon);
                }
            }
        }

    }
}
