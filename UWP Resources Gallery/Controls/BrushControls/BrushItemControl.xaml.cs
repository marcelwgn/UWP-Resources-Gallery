using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using UWPResourcesGallery.Models.Brush;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace UWPResourcesGallery.Controls.BrushControls
{
    public sealed partial class BrushItemControl : UserControl
    {

        #region BrushItem property
        public static DependencyProperty BrushDependencyProperty = DependencyProperty.Register(
                "Brush",
                typeof(BrushItem),
                typeof(BrushItemControl),
                new PropertyMetadata(default(BrushItem), new PropertyChangedCallback(BrushItemChanged))
            );

        public BrushItem Brush {
            get
            {
                return (BrushItem)GetValue(BrushDependencyProperty);
            }
            set
            {
                SetValue(BrushDependencyProperty, value);
                BrushChanged();
            }
        }

        private static void BrushItemChanged(object sender, object e)
        {
            (sender as BrushItemControl).BrushChanged();
        }
        #endregion

        public BrushItemControl()
        {
            this.InitializeComponent();
        }

        private void BrushChanged()
        {

        }
    }
}
