using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Windows.Data.Json;
using Windows.Storage;

namespace UWPResourcesGallery.Model
{
    /// <summary>
    /// Creates a generic data source, capable of:
    /// - storing item list
    /// - filtering items and storing result in <see cref="FilteredItems"/>
    /// - Loading JSON object from file (<see cref="GetJSONFile(string)"/>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class GenericItemsSource<T> where T : IFilterable
    {
        /// <summary>
        /// List containing all items
        /// </summary>
        public static IList<T> Items { get; } = new List<T>();

        /// <summary>
        /// List containg a filtered list. Gets updated when calling <see cref="Filter(string)"/>
        /// </summary>
        public ObservableCollection<T> FilteredItems { get; } = new ObservableCollection<T>();

        protected GenericItemsSource()
        {
            foreach (T item in Items)
            {
                FilteredItems.Add(item);
            }
        }

        /// <summary>
        /// Loads the json file from the apps assets 
        /// </summary>
        /// <param name="fileName">The name of the file (e.g. Items.json) </param>
        /// <returns>The JSON object stored in the document</returns>
        protected static JsonObject GetJSONFile(string fileName)
        {
            Uri iconListJson = new Uri("ms-appx://" + fileName);
            Task<StorageFile> task = StorageFile.GetFileFromApplicationUriAsync(iconListJson).AsTask();
            StorageFile iconFile = task.Result;
            Task<string> fileTask = FileIO.ReadTextAsync(iconFile).AsTask();
            string jsonText = fileTask.Result;

            return JsonObject.Parse(jsonText);
        }

        /// <summary>
        /// Filters the items and updates the <see cref="FilteredItems"/> to only contain the items that are applicable for the filter
        /// </summary>
        /// <param name="search">The search filter</param>
        public void Filter(string search)
        {
            string[] filter = search?.Split(" ");

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
