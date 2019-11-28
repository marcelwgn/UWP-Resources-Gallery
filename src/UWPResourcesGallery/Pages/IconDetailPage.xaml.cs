using System.Threading.Tasks;
using UWPResourcesGallery.Common;
using UWPResourcesGallery.Model.Icon;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

namespace UWPResourcesGallery.Pages
{
    public sealed partial class IconDetailPage : Page
    {
        private IconItem icon;
        private string fontIconCode;

        public IconDetailPage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            var anim = ConnectedAnimationService.GetForCurrentView().GetAnimation("ForwardConnectedAnimation");
            if (anim != null)
            {
                anim.TryStart(TransitionReceiver);
            }
            if (e.Parameter is IconItem ownIcon)
            {
                icon = ownIcon;
                fontIconCode = SampleTemplateProvider.GetFontIconCodeFromGlyph(icon.StringGlyph);
                FontIconCodeSample.Code = fontIconCode;
                CustomIconCode.Code = SampleTemplateProvider.GetCustomizedFontIconCode(icon.StringGlyph, FontIconColorPicker.Color.ToString(), ((int)CustomIconFontSize.Value).ToString());
                SymbolIconCodeSample.Code = SampleTemplateProvider.GetSymbolIconCodeFromGlyph(icon.Name);
                Bindings.Update();
            }
        }

        private void ColorPicker_ColorChanged(Microsoft.UI.Xaml.Controls.ColorPicker sender, Microsoft.UI.Xaml.Controls.ColorChangedEventArgs args)
        {
            LightThemeIcon.Foreground = new SolidColorBrush(args.NewColor);
            DarkThemeIcon.Foreground = new SolidColorBrush(args.NewColor);

            if (icon == null)
            {
                return;
            }
            CustomIconCode.Code = SampleTemplateProvider.GetCustomizedFontIconCode(icon.StringGlyph, args.NewColor.ToString(),((int)CustomIconFontSize.Value).ToString());
        }

        private void Size_ValueChanged(Microsoft.UI.Xaml.Controls.NumberBox sender, Microsoft.UI.Xaml.Controls.NumberBoxValueChangedEventArgs args)
        {
            if (icon == null)
            {
                return;
            }
            CustomIconCode.Code = SampleTemplateProvider.GetCustomizedFontIconCode(icon.StringGlyph, FontIconColorPicker.Color.ToString(), ((int)CustomIconFontSize.Value).ToString());
        }
    }
}
