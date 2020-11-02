using ColorCode;
using Microsoft.AppCenter.Analytics;
using UWPResourcesGallery.Common;
using UWPResourcesGallery.ResourceModel.Icons;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

namespace UWPResourcesGallery.Pages
{
    public sealed partial class IconDetailPage : Page
    {
        private IconItem icon;

        public IconDetailPage()
        {
            InitializeComponent();
            SymbolIconCSCodeSample.SyntaxLanguage = Languages.CSharp;
            ButtonSymbolIconCSCodeSample.SyntaxLanguage = Languages.CSharp;
            FontIconCSCodeSample.SyntaxLanguage = Languages.CSharp;
            ButtonFontIconCSCodeSample.SyntaxLanguage = Languages.CSharp;
            Analytics.TrackEvent("Visited: IconDetailPage");
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e == null)
            {
                return;
            }
            base.OnNavigatedTo(e);
            ConnectedAnimation anim = ConnectedAnimationService.GetForCurrentView().GetAnimation("ForwardConnectedAnimation");
            if (anim != null)
            {
                anim.TryStart(TransitionReceiver);
            }
            if (e.Parameter is IconItem ownIcon)
            {
                icon = ownIcon;
                SymbolIconXAMLCodeSample.Code = SampleTemplateProvider.GetXAMLSymbolIconCodeFromGlyph(icon.Name);
                SymbolIconCSCodeSample.Code = SampleTemplateProvider.GetCSSymbolIconCodeFromGlyph(icon.Name);
                ButtonSymbolIconXAMLCodeSample.Code = SampleTemplateProvider.GetXAMLButtonIconFromSymbolName(icon.Name);
                ButtonSymbolIconCSCodeSample.Code = SampleTemplateProvider.GetCSButtonIconFromSymbolName(icon.Name);

                FontIconXAMLCodeSample.Code = SampleTemplateProvider.GetXAMLFontIconCodeFromGlyph(icon.StringGlyph);
                FontIconCSCodeSample.Code = SampleTemplateProvider.GetCSFontIconCodeFromGlyph(icon.StringGlyph);
                ButtonFontIconXAMLCodeSample.Code = SampleTemplateProvider.GetXAMLButtonIconFromGlyph(icon.StringGlyph);
                ButtonFontIconCSCodeSample.Code = SampleTemplateProvider.GetCSButtonIconFromGlyph(icon.StringGlyph);

                CustomIconCode.Code = SampleTemplateProvider.GetXAMLCustomizedFontIconCode(icon.StringGlyph, FontIconColorPicker.Color.ToString(), ((int)CustomIconFontSize.Value).ToString());
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
            CustomIconCode.Code = SampleTemplateProvider.GetXAMLCustomizedFontIconCode(icon.StringGlyph
                , args.NewColor.ToString()
                , ((int)CustomIconFontSize.Value).ToString());
        }

        private void Size_ValueChanged(Microsoft.UI.Xaml.Controls.NumberBox sender, Microsoft.UI.Xaml.Controls.NumberBoxValueChangedEventArgs args)
        {
            if (icon == null)
            {
                return;
            }
            CustomIconCode.Code = SampleTemplateProvider.GetXAMLCustomizedFontIconCode(icon.StringGlyph
                , FontIconColorPicker.Color.ToString()
                , ((int)CustomIconFontSize.Value).ToString());
        }
    }
}
