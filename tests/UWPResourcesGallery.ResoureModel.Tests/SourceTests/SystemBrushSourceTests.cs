using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;
using UWPResourcesGallery.ResourceModel.Brushes;
using Windows.ApplicationModel.Core;

namespace UWPResourcesGallery.ResoureModel.Tests.SourceTests
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
            SystemBrushItemSource systemBrushSource = new SystemBrushItemSource();

            string brushName = "SystemControlBackgroundAccentBrush";
            string correctXAML = SystemBrushDefinitionFactory.SolidColorBrushDefinition("SystemControlBackgroundAccentBrush", "{ThemeResource SystemAccentColor}");

            systemBrushSource.Filter(brushName);

            Assert.IsTrue(0 < systemBrushSource.FilteredItems.Count);
            foreach (SystemBrush brush in systemBrushSource.FilteredItems)
            {
                Assert.AreEqual(brushName, brush.Key);
                Assert.AreEqual(correctXAML, brush.XAMLDefinition);
            }
        }
    }
}
