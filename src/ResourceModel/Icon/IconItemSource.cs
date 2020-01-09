using System.Threading.Tasks;
using Windows.Data.Json;

namespace UWPResourcesGallery.Model.Icons
{
    public class IconItemSource : GenericItemsSource<IconItem>
    {

        public static void LoadIconsList()
        {
            var file = GetJSONFile("/ResourceModel/Assets/IconList.json");
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
