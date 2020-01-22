using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWPResourcesGallery.Model.WindowsVersionContracts
{
    public class UniversalPlatformContract
    {
        public string Name { get; private set; }
        public string Version { get; private set; }
        public int VersionAsNumber { get; private set; }

        public UniversalPlatformContract(string name, string version)
        {
            Name = name;
            Version = version;
        }
    }
}
