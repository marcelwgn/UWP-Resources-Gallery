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
        public SettingsPage()
        {
            InitializeComponent();

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
