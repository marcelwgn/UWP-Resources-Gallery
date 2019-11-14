using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWPResourcesGallery.Model.Brush;

namespace ResoureModelTests
{
    [TestClass]
    public class BrushSourceTests
    {
        [ClassInitialize]
        public static async Task ClassInitialize(TestContext context)
        {
            await BrushItemSource.LoadBrushList();
        }

        [TestMethod]
        public void VerifyItemsNotNull()
        {
            Assert.IsTrue(BrushItemSource.Items.Count > 0);
            for (int i = 0; i < BrushItemSource.Items.Count; i++)
            {
                Assert.IsNotNull(BrushItemSource.Items[i]);
            }
        }
    }
}
