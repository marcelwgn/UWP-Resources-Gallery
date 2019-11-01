using UWPResourcesGallery.Pages;
using Windows.ApplicationModel.Core;
using Windows.Foundation.Metadata;
using Windows.UI;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using MUXC = Microsoft.UI.Xaml.Controls;

namespace UWPResourcesGallery
{
    /// <summary>
    /// This is the root page of the application
    /// </summary>
    public sealed partial class Navigation : Page
    {

        private static Navigation Instance;

        public static void NavigateToIconsListPage()
        {
            Instance._IconsListPage.IsSelected = true;
            Instance.RootFrame.Navigate(typeof(IconsListPage));
        }

        public Navigation()
        {
            this.InitializeComponent();
            Instance = this;

            Window.Current.SetTitleBar(AppTitleBar);

        
            RootFrame.Navigate(typeof(StartPage));

            Loaded += delegate (object sender, RoutedEventArgs e)
            {
                ApplicationViewTitleBar titleBar = ApplicationView.GetForCurrentView().TitleBar;
                titleBar.ButtonBackgroundColor = Colors.Transparent;
                titleBar.ButtonInactiveBackgroundColor = Colors.Transparent;
            };
        }

        private void RootNavigation_ItemInvoked(MUXC.NavigationView sender, MUXC.NavigationViewItemInvokedEventArgs args)
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
            if(selectedItem == _BrushesListPage)
            {
                RootFrame.Navigate(typeof(SystemBrushesListPage));
            }
        }
        private void UpdateAppTitleMargin(float offSet)
        {
            // We need to check if translations are enabled to update
            if (ApiInformation.IsApiContractPresent("Windows.Foundation.UniversalApiContract", 7))
            {
                AppTitleBar.Translation = new System.Numerics.Vector3(offSet, 0, 0);
            }
            else
            {
                Thickness old = AppTitle.Margin;
                AppTitleBar.Margin = new Thickness(45 + offSet,5,0,0);
            }
        }

        private void RootNavigation_PaneClosing(MUXC.NavigationView sender, MUXC.NavigationViewPaneClosingEventArgs args)
        {
            if(sender.DisplayMode != MUXC.NavigationViewDisplayMode.Minimal)
            {
                UpdateAppTitleMargin(10);
            }
        }

        private void RootNavigation_PaneOpening(MUXC.NavigationView sender, object args)
        {
            if (sender.DisplayMode != MUXC.NavigationViewDisplayMode.Minimal)
            {
                UpdateAppTitleMargin(0);
            }
        }

        private void RootNavigation_DisplayModeChanged(MUXC.NavigationView sender, MUXC.NavigationViewDisplayModeChangedEventArgs args)
        {
            switch (sender.DisplayMode)
            {
                case MUXC.NavigationViewDisplayMode.Minimal:
                    UpdateAppTitleMargin((float)sender.CompactPaneLength);
                    break;
                case MUXC.NavigationViewDisplayMode.Compact:
                    UpdateAppTitleMargin(10);
                    break;
                case MUXC.NavigationViewDisplayMode.Expanded:
                    if (sender.IsPaneOpen)
                    {
                        UpdateAppTitleMargin(0);
                    }
                    else
                    {
                        UpdateAppTitleMargin(10);
                    }
                    break;
            }
        }
    }
}
