using Windows.Data.Json;

namespace UWPResourcesGallery.Model.Colors
{
    public class SystemColorsItemSource : GenericItemsSource<SystemColor>
    {
        public static void LoadSystemColors()
        {
            JsonObject file = GetJSONFile("/ResourceModel/Assets/SystemColors.json");
            JsonArray list = file["colors"].GetArray();
            foreach (JsonValue entry in list)
            {
                JsonObject entryObject = entry.GetObject();
                SystemColor brush = new SystemColor(
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
