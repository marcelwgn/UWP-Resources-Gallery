using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Windows.Data.Json;
using Windows.Storage;

namespace UWPResourcesGallery.Models.Icon
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
