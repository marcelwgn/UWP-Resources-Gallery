using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;
using UWPResourcesGallery.Model.Brushes;
using UWPResourcesGallery.Model.Colors;
using Windows.ApplicationModel.Core;

namespace ResoureModelTests
{
    [TestClass]
    public class SystemBrushSourceTests
    {
        [ClassInitialize]
        public static async Task ClassInitialize(TestContext context)
        {
            if (context is null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            context.WriteLine("Load theme resources");
            // We need the UI thread since we use the XAML loader
            await CoreApplication.MainView.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Low, () =>
            {
                SystemBrushItemSource.LoadSystemBrushes();
            });
        }

        [TestMethod]
        public void VerifyItemsNotNull()
        {
            Assert.IsTrue(SystemBrushItemSource.Items.Count > 0);
            for (int i = 0; i < SystemBrushItemSource.Items.Count; i++)
            {
                Assert.IsNotNull(SystemBrushItemSource.Items[i]);
            }
        }

        [TestMethod]
        public void FiltersCorrectly()
        {
            var systemBrushSource = new SystemBrushItemSource();

            var brushName = "SystemControlBackgroundAccentBrush";
            var correctXAML = SystemBrushDefinitionFactory.SolidColorBrushDefinition("SystemControlBackgroundAccentBrush", "{ThemeResource SystemAccentColor}");

            systemBrushSource.Filter(brushName);

            Assert.IsTrue(0 < systemBrushSource.FilteredItems.Count);
            foreach (var brush in systemBrushSource.FilteredItems)
            {
                Assert.AreEqual(brushName, brush.Key);
                Assert.AreEqual(correctXAML, brush.XAMLDefinition);
            }
        }
    }
}
