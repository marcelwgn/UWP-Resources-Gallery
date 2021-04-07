using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWPResourcesGallery.ResourceModel.WindowsVersionContracts
{
    public class UniversalPlatformContract : IFilterable
    {
        public string Name { get; private set; }
        public string UIAName => "UWP contract " + Name;
        public string Version { get; private set; }
        public int VersionInt => int.Parse(Version.Replace(".0",""));

        public UniversalPlatformContract(string name, string version)
        {
            Name = name;
            Version = version;
        }

        public bool FitsFilter(string[] keywords)
        {
            return keywords.Any(keyword =>
            {
                return FitsFilter(keyword);
            });
        }

        public bool FitsFilter(string keyword)
        {
            return Name.Contains(keyword, StringComparison.InvariantCultureIgnoreCase)
                || Version.Contains(keyword, StringComparison.InvariantCultureIgnoreCase);
        }
    }
}
