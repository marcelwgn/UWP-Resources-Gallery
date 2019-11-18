using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace UWPResourcesGallery.Common
{
#pragma warning disable CA1812 // Avoid uninstantiated internal classes
    internal class BoolToVisibilityConverterClass : IValueConverter
#pragma warning restore CA1812 // Avoid uninstantiated internal classes
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return ((bool)value) ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return ((Visibility)value) == Visibility.Visible;
        }
    }
}
