using System.Collections.Generic;
using Windows.Data.Json;
using System.Linq;
using System.Collections.ObjectModel;

namespace UWPResourcesGallery.Model.Icons
{
    public class IconItemSource : GenericItemsSource<IconItem>
    {
        public ObservableCollection<IconItem> FilteredSymbolItems = new ObservableCollection<IconItem>();

        public IconItemSource()
        {
            foreach (IconItem item in Items)
            {
                FilteredItems.Add(item);
                if (item.IsSymbol)
                {
                    FilteredSymbolItems.Add(item);
                }
            }
        }


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

        public new void Filter(string search)
        {
            string[] filter = search?.Split(" ");

            FilteredItems.Clear();
            FilteredSymbolItems.Clear();

            foreach (IconItem item in Items)
            {
                if (item.FitsFilter(filter))
                {
                    FilteredItems.Add(item);
                    if (item.IsSymbol)
                    {
                        FilteredSymbolItems.Add(item);
                    }
                }
            }
        }
    }
}
