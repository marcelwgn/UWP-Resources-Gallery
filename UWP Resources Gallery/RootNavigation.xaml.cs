using UWPResourcesGallery.Pages;
using Windows.UI.Xaml.Controls;
using MUXC = Microsoft.UI.Xaml.Controls;

namespace UWPResourcesGallery
{
    /// <summary>
    /// This is the root page of the application
    /// </summary>
    public sealed partial class RootNavigation : Page
    {

        private static RootNavigation Instance;

        public static void NavigateToIconsListPage()
        {
            Instance._IconsListPage.IsSelected = true;
            Instance.RootFrame.Navigate(typeof(IconsListPage));
        }

        public RootNavigation()
        {
            Instance = this;
            this.InitializeComponent();
            RootFrame.Navigate(typeof(StartPage));
        }

        private void NavigationView_ItemInvoked(MUXC.NavigationView sender, MUXC.NavigationViewItemInvokedEventArgs args)
        {
            if (args.IsSettingsInvoked)
            {
                RootFrame.Navigate(typeof(SettingsPage));
                return;
            }
            var selectedItem = sender.SelectedItem;
            if (selectedItem == _StartPage)
            {
                RootFrame.Navigate(typeof(StartPage));
            }
            if (selectedItem == _IconsListPage)
            {
                RootFrame.Navigate(typeof(IconsListPage));
            }
        }
    }
}
