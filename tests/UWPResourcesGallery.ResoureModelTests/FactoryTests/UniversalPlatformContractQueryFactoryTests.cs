using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWPResourcesGallery.ResourceModel.WindowsVersionContracts;

namespace UWPResourcesGallery.ResoureModelTests.FactoryTests
{
    [TestClass]
    public class UniversalPlatformContractQueryFactoryTests
    {

        [TestMethod]
        public void VerifyCSharpQueriesIsCorrect()
        {
            var contract = new UniversalPlatformContract("My.Contract", "1.0");

            var CSharpQuery = UniversalPlatformContractQueryFactory.GetCSharpQuery(contract);
            Assert.AreEqual("ApiInformation.IsApiContractPresent(\"My.Contract\", 1)", CSharpQuery);
        }

        [TestMethod]
        public void VerifyXAMLNamespaceIsCorrect()
        {
            var contract = new UniversalPlatformContract("My.AwesomeContract", "1.0");

            var xamlNamespace = UniversalPlatformContractQueryFactory.GetXAMLConditionalNameSpace(contract);
            Assert.AreEqual("xmlns:AwesomeContractVersion1Present=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation?IsApiContractPresent(My.AwesomeContract, 1)\"", xamlNamespace);
        }
    }
}
