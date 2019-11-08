using UWPResourcesGallery.Models.Icon;
using Windows.UI.Xaml.Controls;
using Windows.ApplicationModel.DataTransfer;
using UWPResourcesGallery.Common;
using Windows.UI.Xaml.Navigation;

namespace UWPResourcesGallery.Controls.IconControls
{
    public sealed partial class IconDetailPage : Page
    {
        private IconItem icon;

        public IconDetailPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            IconItem ownIcon = e.Parameter as IconItem;
            if (ownIcon != null)
            {
                this.icon = ownIcon;
                this.FontIconCodeSample.Code = SampleTemplateProvider.GetFontIconCodeFromGlyph(icon.StringGlyph);
                this.SymbolIconCodeSample.Code = SampleTemplateProvider.GetSymbolIconCodeFromGlyph(icon.Name);
                this.Bindings.Update();
            }
        }

    }
}
