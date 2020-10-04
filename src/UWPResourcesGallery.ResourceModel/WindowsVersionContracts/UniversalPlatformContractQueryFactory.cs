using Windows.Foundation.Metadata;

namespace UWPResourcesGallery.ResourceModel.WindowsVersionContracts
{
    public static class UniversalPlatformContractQueryFactory
    {
        public static string GetCSharpQuery(UniversalPlatformContract contract)
        {
            if (contract == null)
            {
                return "";
            }
            return string.Concat("ApiInformation.IsApiContractPresent(\"", contract.Name, "\", ", contract.VersionInt, ")");
        }

        public static string GetXAMLConditionalNameSpace(UniversalPlatformContract contract)
        {
            if (contract == null)
            {
                return "";
            }

            var splitName = contract.Name.Split(".");
            // Construct a suitable namespace name, most contracts are named "...Contract", so this is a reasonable name suggestion
            var name = string.Concat(splitName[splitName.Length - 1], "Version", contract.VersionInt, "Present");
            return string.Concat("xmlns:", name,
                "=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation?IsApiContractPresent(", 
                contract.Name, ", ", contract.VersionInt, ")\"");
        }
    }
}