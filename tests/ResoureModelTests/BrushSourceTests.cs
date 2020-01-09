using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWPResourcesGallery.Model.Brush;
using Windows.ApplicationModel.Core;

namespace ResoureModelTests
{
    [TestClass]
    public class BrushSourceTests
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
                SystemColorsItemSource.LoadSystemColors();
            });
        }

        [TestMethod]
        public void VerifyItemsNotNull()
        {
            Assert.IsTrue(SystemColorsItemSource.Items.Count > 0);
            for (int i = 0; i < SystemColorsItemSource.Items.Count; i++)
            {
                Assert.IsNotNull(SystemColorsItemSource.Items[i]);
            }
        }
    }
}
