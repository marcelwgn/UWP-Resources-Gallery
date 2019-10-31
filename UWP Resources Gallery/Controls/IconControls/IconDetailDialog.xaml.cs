using UWPResourcesGallery.Models.Icon;
using Windows.UI.Xaml.Controls;
using Windows.ApplicationModel.DataTransfer;
using UWPResourcesGallery.Common;


namespace UWPResourcesGallery.Controls.IconControls
{
    public sealed partial class IconDetailDialog : ContentDialog
    {
        private readonly IconItem icon;

        public IconDetailDialog(IconItem icon)
        {
            this.icon = icon;
            this.InitializeComponent();
            this.RequestedTheme = ThemeHelper.AppTheme;
            this.FontIconCodeSample.Code = SampleTemplateProvider.GetFontIconCodeFromGlyph(icon.StringGlyph);
        }
    }
}
