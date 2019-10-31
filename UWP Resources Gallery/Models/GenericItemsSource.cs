using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Json;
using Windows.Storage;

namespace UWPResourcesGallery.Models
{
    public abstract class GenericItemsSource<T> where T : IFilterable
    {
        public static IList<T> Items { get; } = new List<T>();

        public ObservableCollection<T> FilteredItems { get; } = new ObservableCollection<T>();

        public GenericItemsSource()
        {
            foreach (T item in Items)
            {
                FilteredItems.Add(item);
            }
        }

        protected async static Task<JsonObject> GetJSONFile(string fileName)
        {
            Uri iconListJson = new Uri("ms-appx:///Assets/"+fileName);
            StorageFile iconFile = await StorageFile.GetFileFromApplicationUriAsync(iconListJson);
            string jsonText = await FileIO.ReadTextAsync(iconFile);

            return JsonObject.Parse(jsonText);
        }

        public void Filter(string search)
        {
            string[] filter = search.Split(" ");

            FilteredItems.Clear();

            foreach (T item in Items)
            {
                if (item.FitsFilter(filter))
                {
                    FilteredItems.Add(item);
                }
            }
        }
    }
}
