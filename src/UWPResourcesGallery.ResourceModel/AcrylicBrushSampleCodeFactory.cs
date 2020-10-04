using System;
using Windows.UI;

namespace UWPResourcesGallery.ResourceModel
{
    public static class AcrylicBrushSampleCodeFactory
    {
        public static string GetAcrylicBrushXAMLCode(Color color,double tintOpacity, double tintLuminosityOpacity)
        {
            return string.Concat("<AcrylicBrush Color=\"", color.ToString(), "\"\n",
                "    TintOpacity=\"", Math.Round(tintOpacity,2), "\"\n",
                "    contract8Present:TintLuminosityOpacity=\"", Math.Round(tintLuminosityOpacity,2), "\"/>");
        }
    }
}
