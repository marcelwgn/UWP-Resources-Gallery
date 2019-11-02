using UWPResourcesGallery.Models.Icon;
using Windows.UI.Xaml.Controls;
using Windows.ApplicationModel.DataTransfer;
using UWPResourcesGallery.Common;


namespace UWPResourcesGallery.Controls.IconControls
{
    public sealed partial class IconDetailPage : Page
    {
        private readonly IconItem icon;

        public IconDetailPage()
        {
            //this.icon = icon;
            this.InitializeComponent();
            this.RequestedTheme = ThemeHelper.AppTheme;
            //this.FontIconCodeSample.Code = SampleTemplateProvider.GetFontIconCodeFromGlyph(icon.StringGlyph);
        }

        private void Button_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {

        }
    }
}
