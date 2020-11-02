using Microsoft.AppCenter.Analytics;
using System.Threading.Tasks;
using UWPResourcesGallery.Controls.Templates;
using UWPResourcesGallery.ResourceModel.Icons;
using Windows.Foundation.Metadata;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;

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
            InitializeComponent();

            Analytics.TrackEvent("Visited: IconListPage");
            Loaded += LoadIcons;
        }

        private void LoadIcons(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            Focus(Windows.UI.Xaml.FocusState.Programmatic);
            
            // Delegate loading of icons, so we have smooth navigating to this page
            // and not unecessarly block UI Thread
            Task.Run(delegate ()
            {
                _ = Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.High, () =>
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
            IconItemControl container = ((sender as GridView).ContainerFromItem(e.ClickedItem) as GridViewItem).ContentTemplateRoot as IconItemControl;
            ConnectedAnimation animation = ConnectedAnimationService.GetForCurrentView().PrepareToAnimate("ForwardConnectedAnimation", container);
            if (animation != null && ApiInformation.IsApiContractPresent("Windows.Foundation.UniversalApiContract", 7))
            {
                animation.Configuration = new BasicConnectedAnimationConfiguration();
            }
            Frame.Navigate(typeof(IconDetailPage), e.ClickedItem as IconItem, new DrillInNavigationTransitionInfo());
        }

        private void CheckBox_Checked(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            ItemsGridView.ItemsSource = source.FilteredSymbolItems;

        }

        private void CheckBox_Unchecked(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            ItemsGridView.ItemsSource = source.FilteredItems;
        }
    }
}
