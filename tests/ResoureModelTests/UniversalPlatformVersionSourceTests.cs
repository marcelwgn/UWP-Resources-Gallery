using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWPResourcesGallery.Model.WindowsVersionContracts;

namespace ResoureModelTests
{
    [TestClass]
    public class UniversalPlatformVersionSourceTests
    {
        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            if (context is null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            UniversalPlatformVersionSource.LoadWindowsVersionContracts();
        }

        [TestMethod]
        public void LoadsWindowsVersionsCorrectly()
        {
            Assert.IsTrue(UniversalPlatformVersionSource.Items.Count > 8);

            var firstWindowsVersion = UniversalPlatformVersionSource.Items[0];

            Assert.IsNotNull(firstWindowsVersion);
            Assert.IsTrue("1507".Equals(
                firstWindowsVersion.VersionName, StringComparison.InvariantCulture));
            Assert.IsTrue(firstWindowsVersion.VersionContracts.Count > 0);

            var firstActualContract = firstWindowsVersion.VersionContracts[0];
            Assert.IsNotNull(firstActualContract);
            Assert.AreEqual("1.0", firstActualContract.Version);
        }

        [DataTestMethod]
        [DataRow("1507", 1)]
        [DataRow("1507 contract", 1)]
        [DataRow("MachineLearning", 4)]
        [DataRow("Universal", 9)]
        public void FilteringWorksAsExpected(string keywords,int expectedResultsCount)
        {
            var contactSource = new UniversalPlatformVersionSource();

            contactSource.Filter(keywords);
            Assert.AreEqual(expectedResultsCount, contactSource.FilteredItems.Count);
        }
    }
}
