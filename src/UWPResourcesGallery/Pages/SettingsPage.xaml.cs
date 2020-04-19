using Microsoft.AppCenter.Analytics;
using UWPResourcesGallery.Common;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;


namespace UWPResourcesGallery.Pages
{
    /// <summary>
    /// Settings page for the application
    /// </summary>
    public sealed partial class SettingsPage : Page
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "Binding does not work for static fields")]
        public string Version
        {
            get
            {
                Windows.ApplicationModel.PackageVersion version = Windows.ApplicationModel.Package.Current.Id.Version;
                return string.Format("{0}.{1}.{2}.{3}", version.Major, version.Minor, version.Build, version.Revision);
            }
        }

        public SettingsPage()
        {
            InitializeComponent();

            Analytics.TrackEvent("Visited: SettingsPage");
            foreach (FrameworkElement element in ThemePanel.Children)
            {

                if (element is RadioButton radioButton)
                {
                    if (radioButton.Tag?.ToString() == ThemeHelper.AppTheme.ToString())
                    {
                        radioButton.IsChecked = true;
                    }
                }
            }

        }

        private void OnThemeButton_Checked(object sender, RoutedEventArgs e)
        {
            string themeString = (sender as RadioButton).Tag.ToString();

            if (themeString != null)
            {
                ThemeHelper.AppTheme = ThemeHelper.ElementThemeFromName(themeString);
            }
        }
    }
}
