using UWPResourcesGallery.Model.Brush;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace UWPResourcesGallery.Controls.BrushControls
{
    public sealed partial class BrushItemControl : UserControl
    {

        #region BrushItem property
        public static readonly DependencyProperty BrushDependencyProperty = DependencyProperty.Register(
                "Brush",
                typeof(BrushItem),
                typeof(BrushItemControl),
                new PropertyMetadata(default(BrushItem), new PropertyChangedCallback(BrushItemChanged))
            );

        public BrushItem Brush
        {
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
            InitializeComponent();
        }

        private void BrushChanged()
        {
            Bindings.Update();
        }
    }
}
