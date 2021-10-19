using Microsoft.AppCenter.Analytics;
using System.Threading.Tasks;
using UWPResourcesGallery.ResourceModel.Colors;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace UWPResourcesGallery.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SystemColorsPage : Page
    {

        private readonly SystemColorsItemSource source = new SystemColorsItemSource();

        public SystemColorsPage()
        {
            InitializeComponent();
            Loaded += LoadSystemColors;
            Analytics.TrackEvent("Visited: SystemColorsPage");
        }

        private void LoadSystemColors(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            Focus(Windows.UI.Xaml.FocusState.Programmatic);
            // Delegate loading of system colors, so we have smooth navigating to this page 
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
        private void CompactLayoutCheckbox_Checked(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            ItemsGridView.ItemsSource = null;
            ItemsGridView.ItemsSource = source.FilteredItems;
        }

        private void CompactLayoutCheckbox_Unchecked(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            ItemsGridView.ItemsSource = null;
            ItemsGridView.ItemsSource = source.FilteredItems;
        }
    }
}
