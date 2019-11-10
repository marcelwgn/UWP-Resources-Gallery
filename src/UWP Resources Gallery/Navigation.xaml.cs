using System;
using UWPResourcesGallery.Pages;
using Windows.Foundation.Metadata;
using Windows.UI;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using MUXC = Microsoft.UI.Xaml.Controls;

namespace UWPResourcesGallery
{
    /// <summary>
    /// This is the root page of the application
    /// </summary>
    public sealed partial class Navigation : Page
    {

        private static Navigation Instance;

        public static void NavigateToPageType(Type pageType)
        {
            Instance.RootFrame.Navigate(pageType);
        }

        public static void NavigateToIconsListPage()
        {
            Instance._IconsListPage.IsSelected = true;
            Instance.RootFrame.Navigate(typeof(IconsListPage));
        }

        public Navigation()
        {
            InitializeComponent();
            Instance = this;

            Window.Current.SetTitleBar(AppTitleBar);


            RootFrame.Navigate(typeof(StartPage));

            Loaded += delegate (object sender, RoutedEventArgs e)
            {
                ApplicationViewTitleBar titleBar = ApplicationView.GetForCurrentView().TitleBar;
                titleBar.ButtonBackgroundColor = Colors.Transparent;
                titleBar.ButtonInactiveBackgroundColor = Colors.Transparent;

                RootFrame.Navigated += RootFrame_Navigated;
                RootNavigation.BackRequested += RootNavigation_BackRequested;
            };
        }

        private void RootNavigation_BackRequested(MUXC.NavigationView sender, MUXC.NavigationViewBackRequestedEventArgs args)
        {
            if (RootFrame.CanGoBack)
            {
                RootFrame.GoBack();
            }
            RootNavigation.IsBackEnabled = RootFrame.CanGoBack;
        }

        private void RootFrame_Navigated(object sender, NavigationEventArgs e)
        {
            RootNavigation.IsBackEnabled = RootFrame.CanGoBack;
            if (RootFrame.CurrentSourcePageType == typeof(SettingsPage))
            {
                RootNavigation.SelectedItem = RootNavigation.SettingsItem;
            }
            if (RootFrame.CurrentSourcePageType == typeof(StartPage))
            {
                RootNavigation.SelectedItem = _StartPage;
            }
            if (RootFrame.CurrentSourcePageType == typeof(IconsListPage))
            {
                RootNavigation.SelectedItem = _IconsListPage;
            }
            if (RootFrame.CurrentSourcePageType == typeof(SystemBrushesListPage))
            {
                RootNavigation.SelectedItem = _BrushesListPage;
            }
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
            if (selectedItem == _BrushesListPage)
            {
                RootFrame.Navigate(typeof(SystemBrushesListPage));
            }
        }


        private void UpdateAppTitleBarPosition(float offSet)
        {
            // We need to check if translations are available to update
            if (ApiInformation.IsApiContractPresent("Windows.Foundation.UniversalApiContract", 7))
            {
                // They are available, use smooth transitions
                AppTitleBar.Translation = new System.Numerics.Vector3(offSet, 0, 0);
            }
            else
            {
                // They are not, use margin
                Thickness old = AppTitle.Margin;
                AppTitleBar.Margin = new Thickness(45 + offSet, 5, 0, 0);
            }
        }

        private void RootNavigation_PaneClosing(MUXC.NavigationView sender, MUXC.NavigationViewPaneClosingEventArgs args)
        {
            if (sender.DisplayMode != MUXC.NavigationViewDisplayMode.Minimal)
            {
                UpdateAppTitleBarPosition(20);
            }
        }

        private void RootNavigation_PaneOpening(MUXC.NavigationView sender, object args)
        {
            if (sender.DisplayMode != MUXC.NavigationViewDisplayMode.Minimal)
            {
                UpdateAppTitleBarPosition(0);
            }
        }

        private void RootNavigation_DisplayModeChanged(MUXC.NavigationView sender, MUXC.NavigationViewDisplayModeChangedEventArgs args)
        {
            switch (sender.DisplayMode)
            {
                case MUXC.NavigationViewDisplayMode.Minimal:
                    UpdateAppTitleBarPosition((float)sender.CompactPaneLength);
                    break;
                case MUXC.NavigationViewDisplayMode.Compact:
                    UpdateAppTitleBarPosition(20);
                    break;
                case MUXC.NavigationViewDisplayMode.Expanded:
                    if (sender.IsPaneOpen)
                    {
                        UpdateAppTitleBarPosition(0);
                    }
                    else
                    {
                        UpdateAppTitleBarPosition(20);
                    }
                    break;
            }
        }
    }
}
