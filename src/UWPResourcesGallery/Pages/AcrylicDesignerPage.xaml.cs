using Microsoft.AppCenter.Analytics;
using UWPResourcesGallery.ResourceModel;
using Windows.Foundation.Metadata;
using Windows.UI.Xaml.Controls;
using MUXC = Microsoft.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;

namespace UWPResourcesGallery.Pages
{
    public sealed partial class AcrylicDesignerPage : Page
    {
        public AcrylicDesignerPage()
        {
            InitializeComponent();
            Analytics.TrackEvent("Visited: AcrylicDesignerPage");
        }

        private void TintOpacity_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            UpdateAcrylicBrushes();
        }

        private void TintLuminosity_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            UpdateAcrylicBrushes();
        }

        private void Color_ColorChanged(MUXC.ColorPicker sender, MUXC.ColorChangedEventArgs args)
        {
            UpdateAcrylicBrushes();
        }

        private void UpdateAcrylicBrushes()
        {
            double tintOpacity = TintOpacity != null ? TintOpacity.Value : 0.5;
            double tintLuminosityOpacity = TintLuminosity != null ? TintLuminosity.Value : 0.5;

            HostBackDropBrush.TintColor = Color.Color;
            HostBackDropBrush.FallbackColor = Color.Color;
            if (ApiInformation.IsPropertyPresent("Windows.UI.Xaml.Media.AcrylicBrush", "TintLuminosityOpacity"))
            {
                HostBackDropBrush.TintLuminosityOpacity = tintLuminosityOpacity;
            }
            HostBackDropBrush.TintOpacity = tintOpacity;


            BackDropBrush.TintColor = Color.Color;
            if (ApiInformation.IsPropertyPresent("Windows.UI.Xaml.Media.AcrylicBrush", "TintLuminosityOpacity"))
            {
                BackDropBrush.TintLuminosityOpacity = tintLuminosityOpacity;
            }
            BackDropBrush.TintOpacity = tintOpacity;

            AcrylicBrushSourceCode.Code = AcrylicBrushSampleCodeFactory.GetAcrylicBrushXAMLCode(Color.Color, tintOpacity, tintLuminosityOpacity);
        }
    }
}
