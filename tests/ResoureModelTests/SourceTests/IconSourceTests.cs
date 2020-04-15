using Microsoft.VisualStudio.TestTools.UnitTesting;
using UWPResourcesGallery.Model.Icons;

namespace ResoureModelTests.SourceTests
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

        [TestMethod]
        public void SymbolsOnlyFilterIsCorrect()
        {
            var source = new IconItemSource();
            source.Filter("Global");
            foreach (var item in source.FilteredSymbolItems)
            {
                Assert.IsTrue(item.IsSymbol);
            }

            source.Filter("ED55");
            Assert.IsTrue(source.FilteredSymbolItems.Count == 0);
        }
    }
}
