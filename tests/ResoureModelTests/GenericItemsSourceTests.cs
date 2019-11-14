
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UWPResourcesGallery.Model;

namespace ResoureModelTests
{

    [TestClass]
    public class GenericItemsSourceTests : GenericItemsSource<FilterableString>
    {
        [ClassInitialize]
        public static async Task ClassSetup(TestContext context)
        {
            var file = await GetJSONFile("/Assets/testdata.json");

            foreach (var element in file["strings"].GetArray())
            {
                Items.Add(new FilterableString(element.GetString()));
            }
        }
        
        [TestMethod]
        public void LoadsDataCorrectly()
        {
            Assert.IsTrue(Items.Count > 0);
            
            for (int i = 0; i < Items.Count; i++)
            {
                Assert.AreEqual("Item" + i, Items[i].Value);
            }
        }

        [TestMethod]
        public void FilterWorksCorrectly()
        {
            Assert.IsTrue(Items.Count > 0);

            for (int i = 0; i < Items.Count; i++)
            {
                Filter("Item" + i);
                Assert.AreEqual(1, FilteredItems.Count);
                Assert.AreEqual("Item" + i, FilteredItems[0].Value);

                Filter("Item " + i);
                Assert.AreEqual(1, FilteredItems.Count);
                Assert.AreEqual("Item" + i, FilteredItems[0].Value);
            }

        }
    }

    public class FilterableString : IFilterable
    {
        public string Value;

        public FilterableString(string value)
        {
            Value = value;
        }

        public bool FitsFilter(string[] keywords)
        {
            return keywords.All(key => Value.Contains(key));
        }
    }
}
