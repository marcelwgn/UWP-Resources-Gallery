using UWPResourcesGallery.Controls;
using UWPResourcesGallery.Models.Icon;
using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using UWPResourcesGallery.Controls.IconControls;
using Windows.UI.Xaml.Media.Animation;
using System.Diagnostics;

namespace UWPResourcesGallery.Pages
{
    /// <summary>
    /// Page displaying list of icons
    /// </summary>
    public sealed partial class IconsListPage : Page
    {
        private readonly IconItemSource source = new IconItemSource();

        public IconsListPage()
        {
            this.InitializeComponent();

            this.Loaded += this.LoadIcons;
        }

        private void LoadIcons(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            Task.Run(delegate ()
            {
                _ = Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Low, () =>
                {
                    ItemsGridView.ItemsSource = source.FilteredItems;
                });
            });
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs args)
        {
            source.Filter((sender as TextBox).Text);
        }

        private void ItemsGridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            Frame.Navigate(typeof(IconDetailPage),e.ClickedItem as IconItem,new SuppressNavigationTransitionInfo());
            Debug.WriteLine(Frame.CanGoBack);
        }
    }
}
