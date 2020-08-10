using Microsoft.AppCenter.Analytics;
using UWPResourcesGallery.Model;
using Windows.Foundation.Metadata;
using Windows.UI.Xaml.Controls;
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

        private void Color_ColorChanged(ColorPicker sender, ColorChangedEventArgs args)
        {
            UpdateAcrylicBrushes();
        }

        private void UpdateAcrylicBrushes()
        {
            double tintOpacity = TintOpacity != null ? TintOpacity.Value : 0.5;
            double tintLuminosityOpacity = TintLuminosity != null ? TintLuminosity.Value : 0.5;

            HostBackDropBrush.TintColor = Color.Color;
            if(ApiInformation.IsApiContractPresent("Windows.Foundation.UniversalApiContract", 7))
            {
                HostBackDropBrush.TintLuminosityOpacity = tintLuminosityOpacity;
            }
            HostBackDropBrush.TintOpacity = tintOpacity;


            BackDropBrush.TintColor = Color.Color;
            if (ApiInformation.IsApiContractPresent("Windows.Foundation.UniversalApiContract", 7))
            {
                BackDropBrush.TintLuminosityOpacity = tintLuminosityOpacity;
            }
            BackDropBrush.TintOpacity = tintOpacity;

            AcrylicBrushSourceCode.Code = AcrylicBrushSampleCodeFactory.GetAcrylicBrushXAMLCode(Color.Color, tintOpacity, tintLuminosityOpacity);
        }
    }
}
