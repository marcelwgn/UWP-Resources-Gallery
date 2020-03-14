using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWPResourcesGallery.Model.WindowsVersionContracts
{
    public static class UniversalPlatformContractQueryFactory
    {
        public static string GetCSharpQuery(UniversalPlatformContract contract)
        {
            if (contract == null)
            {
                throw new ArgumentNullException(nameof(contract));
            }
            return string.Concat("ApiInformation.IsContractPresent(\"", contract.Name, "\", ", contract.VersionInt, ")");
        }

        public static string GetXAMLConditionalNameSpace(UniversalPlatformContract contract)
        {
            if(contract == null)
            {
                throw new ArgumentNullException(nameof(contract));
            }
            var splitName = contract.Name.Split(".");
            var name = string.Concat("Contract", splitName[splitName.Length - 1], "Version", contract.VersionInt, "Present");
            return string.Concat("xmlns:", name,
                "=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation?IsApiContractPresent(", 
                contract.Name, ", ", contract.VersionInt, ")\"");
        }

    }
}
