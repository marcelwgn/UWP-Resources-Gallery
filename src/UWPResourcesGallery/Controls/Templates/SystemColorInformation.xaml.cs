using System;
using UWPResourcesGallery.Model.Colors;
using Windows.ApplicationModel.DataTransfer;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace UWPResourcesGallery.Controls.Templates
{
    public sealed partial class SystemColorInformation : UserControl
    {
        private SystemColor SystemColor;

        public SystemColorInformation(SystemColor systemColor)
        {
            SystemColor = systemColor ?? throw new ArgumentNullException(nameof(systemColor));

            InitializeComponent();

            UpdateSnippets();
        }

        private void UpdateSnippets()
        {
            lightThemeHexCodeBlock.Text = SystemColor.LightHex.Substring(0, 3);
            darkThemeHexCodeBlock.Text = SystemColor.DarkHex.Substring(0, 3);

            if (!SystemColor.LightHex.Equals("N/A", StringComparison.InvariantCultureIgnoreCase))
            {
                int lastIndex = 3;
                for (int curIndex = 0; curIndex < 3; curIndex++)
                {
                    lightThemeHexCodeBlock.Text += " " + SystemColor.LightHex.Substring(lastIndex, 2);
                    darkThemeHexCodeBlock.Text += " " + SystemColor.DarkHex.Substring(lastIndex, 2);
                    lastIndex += 2;
                }
            }

            ThemeresourceCodeSample.Code = SystemColor.ThemeResourceString;
            UpdateLayout();
        }

        private void CopyLightThemeHexCode(object sender, RoutedEventArgs e)
        {
            DataPackage package = new DataPackage();
            package.SetText(SystemColor.LightHex);
            Clipboard.SetContent(package);
        }
        private void CopyDarkThemeHexCode(object sender, RoutedEventArgs e)
        {
            DataPackage package = new DataPackage();
            package.SetText(SystemColor.DarkHex);
            Clipboard.SetContent(package);
        }
    }
}
