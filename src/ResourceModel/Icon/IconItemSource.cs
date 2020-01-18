using Windows.Data.Json;

namespace UWPResourcesGallery.Model.Icons
{
    public class IconItemSource : GenericItemsSource<IconItem>
    {

        public static void LoadIconsList()
        {
            JsonObject file = GetJSONFile("/ResourceModel/Assets/IconList.json");
            JsonArray list = file["icons"].GetArray();
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
