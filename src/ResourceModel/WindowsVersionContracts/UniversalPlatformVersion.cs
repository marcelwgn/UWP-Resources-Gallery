using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Json;

namespace UWPResourcesGallery.Model.WindowsVersionContracts
{
    public class UniversalPlatformVersion : IFilterable
    {
        public string Version { get; private set; }
        public string BuildVersion { get; private set; }
        public string VersionName { get; private set; }
        public string MarketingName { get; private set; }
        public string CodeName { get; private set; }

        public List<UniversalPlatformContract> VersionContracts { get; private set; } = new List<UniversalPlatformContract>();
        public ObservableCollection<UniversalPlatformContract> FilteredContracts { get; private set; } = new ObservableCollection<UniversalPlatformContract>();

        public UniversalPlatformVersion(string version, string buildVersion,
            string versionName, string marketingName,
            string codeName, JsonArray contractsArray)
        {
            Version = version;
            BuildVersion = buildVersion;
            VersionName = versionName;
            MarketingName = marketingName;
            CodeName = codeName;

            if(contractsArray == null)
            {
                return;
            }

            UniversalPlatformContract contract = null;
            for (uint index = 0; index < contractsArray.Count; index++)
            {
                JsonObject entry = contractsArray.GetObjectAt(index);

                contract = new UniversalPlatformContract(
                        entry["name"].GetString(),
                        entry["version"].GetString()
                    );
                VersionContracts.Add(contract);
                FilteredContracts.Add(contract);
            }
        }

        public int FilteredContractsCount(string keyword)
        {
            int count = 0;
            foreach(var item in FilteredContracts)
            {
                count += item.FitsFilter(keyword) ? 1 : 0;
            }
            return count;
        }

        public bool FitsFilter(string[] keywords)
        {
            FilteredContracts.Clear();
            VersionContracts.ForEach(contract =>
            {
                if (contract.FitsFilter(keywords))
                {
                    FilteredContracts.Add(contract);
                }
            });
            return keywords.All(key =>
                    {
                        if (Version.Contains(key, StringComparison.InvariantCultureIgnoreCase))
                        {
                            return true;
                        }
                        if (BuildVersion.Contains(key, StringComparison.InvariantCultureIgnoreCase))
                        {
                            return true;
                        }
                        if (VersionName.Contains(key, StringComparison.InvariantCultureIgnoreCase))
                        {
                            return true;
                        }
                        if (MarketingName.Contains(key, StringComparison.InvariantCultureIgnoreCase))
                        {
                            return true;
                        }
                        if (CodeName.Contains(key, StringComparison.InvariantCultureIgnoreCase))
                        {
                            return true;
                        }
                        if(FilteredContractsCount(key) > 0)
                        {
                            return true;
                        }
                        // No matches, return false
                        return false;
                    }
                );
        }
    }
}
