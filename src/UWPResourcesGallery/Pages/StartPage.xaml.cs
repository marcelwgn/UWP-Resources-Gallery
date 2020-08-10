using Microsoft.AppCenter.Analytics;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace UWPResourcesGallery.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class StartPage : Page
    {
        public StartPage()
        {
            InitializeComponent();
            Analytics.TrackEvent("Visited: StartPage");
        }

        private void NavigateToIconListPage_Click(object sender, RoutedEventArgs e)
        {
            AppNavigation.NavigateToPageType(typeof(IconsListPage));
        }

        private void NavigateToSystemBrushesPage_Click(object sender, RoutedEventArgs e)
        {
            AppNavigation.NavigateToPageType(typeof(SystemBrushesPage));
        }

        private void NavigateToSystemColorsPage_Click(object sender, RoutedEventArgs e)
        {
            AppNavigation.NavigateToPageType(typeof(SystemColorsPage));
        }

        private void NavigateToUniversalContractsPage_Click(object sender, RoutedEventArgs e)
        {
            AppNavigation.NavigateToPageType(typeof(UniversalContractsPage));
        }

        private void NavigateToAcrylicBrushDesignerPage_Click(object sender, RoutedEventArgs e)
        {
            AppNavigation.NavigateToPageType(typeof(AcrylicDesignerPage));
        }
    }
}
