using System;
using Windows.Storage;
using Windows.UI;
using Windows.UI.Core;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;

namespace UWPResourcesGallery.Common
{
    public static class ThemeHelper
    {
        private const string SelectedAppThemeKey = "SelectedAppTheme";
        private static Window ApplicationWindow = null;

        private static UISettings uiSettings;
        public static ElementTheme AppTheme
        {
            get
            {
                if (Window.Current.Content is FrameworkElement rootElement)
                {
                    return rootElement.RequestedTheme;
                }
                return ElementTheme.Default;
            }

            set
            {
                ApplicationData.Current.LocalSettings.Values[SelectedAppThemeKey] = value.ToString();

                if (Window.Current.Content is FrameworkElement rootElement)
                {
                    rootElement.RequestedTheme = value;
                }

                UpdateTitleBarButtonColors();
            }
        }

        public static bool IsDarkTheme()
        {
            if (AppTheme == ElementTheme.Default &&
                App.Current.RequestedTheme == ApplicationTheme.Dark)
            {
                return true;
            }
            return AppTheme == ElementTheme.Dark;
        }

        internal static void Initialize()
        {
            ApplicationWindow = Window.Current;
            var savedTheme = ApplicationData.Current.LocalSettings.Values[SelectedAppThemeKey];
            if (savedTheme != null)
            {
                if (Window.Current.Content is FrameworkElement rootElement)
                {
                    rootElement.RequestedTheme = ElementThemeFromName(savedTheme.ToString());
                }

                UpdateTitleBarButtonColors();
            }

            uiSettings = new UISettings();
            uiSettings.ColorValuesChanged += UiSettings_ColorValuesChanged;
        }

        private static async void UiSettings_ColorValuesChanged(UISettings sender, object args)
        {
            if (ApplicationWindow != null)
            {
                await ApplicationWindow.Dispatcher.RunAsync(CoreDispatcherPriority.High, () =>
                    {
                        UpdateTitleBarButtonColors();
                    });
            }
        }

        public static void UpdateTitleBarButtonColors()
        {
            ApplicationViewTitleBar titleBar = ApplicationView.GetForCurrentView().TitleBar;
            if (IsDarkTheme())
            {
                // Darktheme, set tilebar buttons to white
                titleBar.ButtonForegroundColor = Colors.White;
            }
            else
            {
                // Lighttheme, set titlebar buttons to black
                titleBar.ButtonForegroundColor = Colors.Black;
            }
        }

        public static ElementTheme ElementThemeFromName(string name)
        {
            return (ElementTheme)Enum.Parse(typeof(ElementTheme), name);
        }
    }
}
