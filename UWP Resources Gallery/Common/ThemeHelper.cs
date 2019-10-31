using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.UI.Xaml;

namespace UWPResourcesGallery.Common
{
    public static class ThemeHelper
    {
        private const string SelectedAppThemeKey = "SelectedAppTheme";

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
            }
        }

        public static bool IsDarkTheme()
        {
            if(AppTheme == ElementTheme.Default &&
                App.Current.RequestedTheme == ApplicationTheme.Dark)
            {
                return true;
            }
            return AppTheme == ElementTheme.Dark;
        }

        internal static void Initialize()
        {
            var savedTheme = ApplicationData.Current.LocalSettings.Values[SelectedAppThemeKey];
            if (savedTheme != null)
            {
                //AppTheme = ElementThemeFromName(savedTheme.ToString());
                if (Window.Current.Content is FrameworkElement rootElement)
                {
                    rootElement.RequestedTheme = ElementThemeFromName(savedTheme.ToString());
                }
            }
        }

        public static ElementTheme ElementThemeFromName(string name)
        {
            return (ElementTheme)Enum.Parse(typeof(ElementTheme), name);
        }
    }
}
