using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Json;

namespace UWPResourcesGallery.Model.WindowsVersionContracts
{
    public class UniversalPlatformVersionSource : GenericItemsSource<UniversalPlatformVersion>
    {
        public static void LoadWindowsVersionContracts()
        {
            JsonObject file = GetJSONFile("/ResourceModel/Assets/UniversalContracts.json");
            JsonArray list = file["contracts"].GetArray();
            lock (Items)
            {
                foreach (JsonValue entry in list)
                {
                    JsonObject entryObject = entry.GetObject();
                    UniversalPlatformVersion icon = new UniversalPlatformVersion(
                            entryObject["version"].GetString(),
                            entryObject["buildVersion"].GetString(),
                            entryObject["versionName"].GetString(),
                            entryObject["marketingName"].GetString(),
                            entryObject["codeName"].GetString(),
                            entryObject["versionContracts"].GetArray()
                        );
                    Items.Add(icon);
                }
            }
        }
    }
}
