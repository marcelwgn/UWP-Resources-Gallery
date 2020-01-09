using Microsoft.VisualStudio.TestTools.UnitTesting;
using UWPResourcesGallery.Model.Icons;

namespace ResoureModelTests
{
    [TestClass]
    public class IconSourceTests
    {
        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            IconItemSource.LoadIconsList();
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
