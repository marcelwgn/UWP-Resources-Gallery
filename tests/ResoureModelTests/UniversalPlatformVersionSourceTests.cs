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

        [TestMethod]
        public void LoadsWindowsVersionsCorrectly()
        {
            UniversalPlatformContractsSource.LoadWindowsVersionContracts();

            Assert.IsTrue(UniversalPlatformContractsSource.Items.Count > 8);

            var firstWindowsVersion = UniversalPlatformContractsSource.Items[0];

            Assert.IsNotNull(firstWindowsVersion);
            Assert.IsTrue("1507".Equals(
                firstWindowsVersion.VersionName, StringComparison.InvariantCulture));
            Assert.IsTrue(firstWindowsVersion.VersionContracts.Length > 0);

            var firstActualContract = firstWindowsVersion.VersionContracts[0];
            Assert.IsNotNull(firstActualContract);
            Assert.AreEqual("1.0", firstActualContract.Version);
        }

    }
}
