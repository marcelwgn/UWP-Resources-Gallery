
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using UWPResourcesGallery.Model;

namespace ResoureModelTests
{

    [TestClass]
    public class GenericItemsSourceTests : GenericItemsSource<FilterableString>
    {
        [ClassInitialize]
        public static void ClassSetup(TestContext context)
        {
            context?.WriteLine("Started loading test setup");
            Windows.Data.Json.JsonObject file = GetJSONFile("/Assets/testdata.json");

            foreach (Windows.Data.Json.IJsonValue element in file["strings"].GetArray())
            {
                Items.Add(new FilterableString(element.GetString()));
            }
            context?.WriteLine("Finished test setup");
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

            Filter("");

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
        public string Value { get; set; }

        public FilterableString(string value)
        {
            Value = value;
        }

        public bool FitsFilter(string[] keywords)
        {
            return keywords.All(key => Value.Contains(key, StringComparison.InvariantCultureIgnoreCase));
        }
    }
}
