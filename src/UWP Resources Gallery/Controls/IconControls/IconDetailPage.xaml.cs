using UWPResourcesGallery.Common;
using UWPResourcesGallery.Model.Icon;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace UWPResourcesGallery.Controls.IconControls
{
    public sealed partial class IconDetailPage : Page
    {
        private IconItem icon;

        public IconDetailPage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if (e.Parameter is IconItem ownIcon)
            {
                icon = ownIcon;
                FontIconCodeSample.Code = SampleTemplateProvider.GetFontIconCodeFromGlyph(icon.StringGlyph);
                SymbolIconCodeSample.Code = SampleTemplateProvider.GetSymbolIconCodeFromGlyph(icon.Name);
                Bindings.Update();
            }
        }

    }
}
