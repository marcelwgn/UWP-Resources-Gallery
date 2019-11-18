using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWPResourcesGallery.Model.Icon;

namespace ResoureModelTests
{
    [TestClass]
    public class IconSourceTests
    {
        [ClassInitialize]
        public static async Task ClassInitialize(TestContext _)
        {
            await IconItemSource.LoadIconsList();
        }

        [TestMethod]
        public void VerifyItemsNotNull()
        {
            Assert.IsTrue(IconItemSource.Items.Count > 0);
            for (int i = 0; i < IconItemSource.Items.Count; i++)
            {
                Assert.IsNotNull(IconItemSource.Items[i]);
            }
        }
    }
}
