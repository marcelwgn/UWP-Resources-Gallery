using System;
using UWPResourcesGallery.Pages;
using Windows.Foundation.Metadata;
using Windows.UI;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Automation;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using MUXC = Microsoft.UI.Xaml.Controls;

namespace UWPResourcesGallery
{
    /// <summary>
    /// This is the root page of the application
    /// </summary>
    public sealed partial class AppNavigation : Page
    {

        private static AppNavigation Instance;

        public AppNavigation()
        {
            InitializeComponent();
            Instance = this;

            Window.Current.SetTitleBar(WindowDraggingArea);

            RootFrame.Navigate(typeof(StartPage));

            var value = Windows.UI.Core.SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility;


            Loaded += delegate (object sender, RoutedEventArgs e)
            {
                ApplicationViewTitleBar titleBar = ApplicationView.GetForCurrentView().TitleBar;

                titleBar.ButtonBackgroundColor = Colors.Transparent;
                titleBar.ButtonInactiveBackgroundColor = Colors.Transparent;

                RootFrame.Navigated += RootFrame_Navigated;
                RootNavigation.BackRequested += RootNavigation_BackRequested;

                if (!ApplicationView.GetForCurrentView().IsViewModeSupported(ApplicationViewMode.CompactOverlay))
                {
                    SwitchCompactOverlayModeButton.Visibility = Visibility.Collapsed;
                }
                RootNavigation.IsPaneOpen = true;
            };
        }

        public static void NavigateToPageType(Type pageType)
        {
            Instance.RootFrame.Navigate(pageType);
        }

        public static void NavigateToIconsListPage()
        {
            Instance._IconsListPage.IsSelected = true;
            Instance.RootFrame.Navigate(typeof(IconsListPage));
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
            else if (RootFrame.CurrentSourcePageType == typeof(StartPage))
            {
                RootNavigation.SelectedItem = _StartPage;
            }
            else if (RootFrame.CurrentSourcePageType == typeof(IconsListPage))
            {
                RootNavigation.SelectedItem = _IconsListPage;
            }
            else if (RootFrame.CurrentSourcePageType == typeof(SystemColorsPage))
            {
                RootNavigation.SelectedItem = _SystemColorsPage;
            }
            else if (RootFrame.CurrentSourcePageType == typeof(SystemBrushesPage))
            {
                RootNavigation.SelectedItem = _SystemBrushesPage;
            }
            else if (RootFrame.CurrentSourcePageType == typeof(AcrylicDesignerPage))
            {
                RootNavigation.SelectedItem = _AcrylicBrushDesigner;
            }
            else if (RootFrame.CurrentSourcePageType == typeof(UniversalContractsPage))
            {
                RootNavigation.SelectedItem = _UniversalContractsPage;
            }

        }

        private void RootNavigation_ItemInvoked(MUXC.NavigationView sender, MUXC.NavigationViewItemInvokedEventArgs args)
        {
            if (args.IsSettingsInvoked)
            {
                RootFrame.Navigate(typeof(SettingsPage));
                return;
            }
            else if ((string)args.InvokedItem == "Start")
            {
                RootFrame.Navigate(typeof(StartPage));
            }
            else if ((string)args.InvokedItem == "Icons")
            {
                RootFrame.Navigate(typeof(IconsListPage));
            }
            else if ((string)args.InvokedItem == "Systemcolors")
            {
                RootFrame.Navigate(typeof(SystemColorsPage));
            }
            else if ((string)args.InvokedItem == "Systembrushes")
            {
                RootFrame.Navigate(typeof(SystemBrushesPage));
            }
            else if ((string)args.InvokedItem == "AcrylicBrush designer")
            {
                RootFrame.Navigate(typeof(AcrylicDesignerPage));
            }
            else if ((string)args.InvokedItem == "Universal API contracts")
            {
                RootFrame.Navigate(typeof(UniversalContractsPage));
            }
        }

        // App title code 
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
                AppTitleBar.Margin = new Thickness(45 + offSet, 5, 0, 0);
            }
        }

        private void RootNavigation_PaneClosing(MUXC.NavigationView sender, MUXC.NavigationViewPaneClosingEventArgs args)
        {
            if (sender.DisplayMode != MUXC.NavigationViewDisplayMode.Minimal)
            {
                UpdateAppTitleBarPosition(15);
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
                    UpdateAppTitleBarPosition((float)sender.CompactPaneLength + 5);
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

        private async void SwitchCompactOverlayModeButton_Click(object sender, RoutedEventArgs e)
        {
            if (ApplicationView.GetForCurrentView().ViewMode == ApplicationViewMode.Default)
            {
                bool modeSwitched = await ApplicationView.GetForCurrentView().TryEnterViewModeAsync(ApplicationViewMode.CompactOverlay);
                Windows.UI.ViewManagement.ApplicationView.GetForCurrentView().SetPreferredMinSize(new Windows.Foundation.Size(150, 50));
                if (modeSwitched)
                {
                    VisualStateManager.GoToState(this, "CompactOverlay", false);
                }
            }
            else
            {
                bool modeSwitched = await ApplicationView.GetForCurrentView().TryEnterViewModeAsync(ApplicationViewMode.Default);
                if (modeSwitched)
                {
                    VisualStateManager.GoToState(this, "NoOverlay", false);
                }
            }
        }
    }
}
