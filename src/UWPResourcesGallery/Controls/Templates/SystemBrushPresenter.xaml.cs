using Microsoft.UI.Xaml.Controls;
using UWPResourcesGallery.ResourceModel.Brushes;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace UWPResourcesGallery.Controls.Templates
{
    public sealed partial class SystemBrushPresenter : UserControl
    {

        #region SystemBrushItem property
        public static readonly DependencyProperty SystemBrushItemDependencyProperty = DependencyProperty.Register(
                "SystemBrush",
                typeof(SystemBrush),
                typeof(SystemBrushPresenter),
                new PropertyMetadata(default(SystemBrush), new PropertyChangedCallback(SystemBrushItemChanged))
            );

        public SystemBrush SystemBrush
        {
            get => (SystemBrush)GetValue(SystemBrushItemDependencyProperty);
            set
            {
                SetValue(SystemBrushItemDependencyProperty, value);
                SystemBrushChanged();
            }
        }

        private static void SystemBrushItemChanged(object sender, object e)
        {
            (sender as SystemBrushPresenter).SystemBrushChanged();
        }
        #endregion

        public bool UseCompactLayout
        {
            get { return (bool)GetValue(UseCompactLayoutProperty); }
            set { SetValue(UseCompactLayoutProperty, value); }
        }

        // Using a DependencyProperty as the backing store for UseCompactLayout.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty UseCompactLayoutProperty =
            DependencyProperty.Register(
                "UseCompactLayout",
                typeof(bool),
                typeof(SystemBrushPresenter),
                new PropertyMetadata(false,
                new PropertyChangedCallback(OnUseCompactLayoutPropertyChanged)));

        private static void OnUseCompactLayoutPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            SystemBrushPresenter control = d as SystemBrushPresenter;
            control.UseCompactLayoutChanged();
        }

        public SystemBrushPresenter()
        {
            InitializeComponent();
        }

        private void SystemBrushChanged()
        {
            Bindings.Update();
        }

        private void OpenInfoTeachingTipButton_Click(object sender, RoutedEventArgs e)
        {
            TeachingTip teachingTip = Resources["InfoTeachingTip"] as TeachingTip;
            teachingTip.Content = new SystemBrushInformation(SystemBrush);
            teachingTip.Target = OpenInfoTeachingTipButton;
            teachingTip.IsOpen = true;
            teachingTip.Width = 800;
            teachingTip.Subtitle = "";

            teachingTip.UpdateLayout();
        }

        private void UseCompactLayoutChanged()
        {
            if (UseCompactLayout)
            {
                VisualStateManager.GoToState(this, "CompactLayout", false);
                ToolTipService.SetToolTip(this, "Brush: " + SystemBrush.Key);
            }
            else
            {
                VisualStateManager.GoToState(this, "NormalLayout", false);
                ToolTipService.SetToolTip(this, null);
            }
        }
    }
}
