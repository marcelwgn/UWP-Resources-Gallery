using Microsoft.UI.Xaml.Controls;
using UWPResourcesGallery.ResourceModel.Colors;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace UWPResourcesGallery.Controls.Templates
{
    public sealed partial class SystemColorPresenter : UserControl
    {

        #region SystemColorItem property
        public static readonly DependencyProperty SystemColorItemDependencyProperty = DependencyProperty.Register(
                "SystemColor",
                typeof(SystemColor),
                typeof(SystemColorPresenter),
                new PropertyMetadata(default(SystemColor), new PropertyChangedCallback(SystemColorItemChanged))
            );

        public SystemColor SystemColor
        {
            get => (SystemColor)GetValue(SystemColorItemDependencyProperty);
            set
            {
                SetValue(SystemColorItemDependencyProperty, value);
                SystemColorChanged();
            }
        }

        private static void SystemColorItemChanged(object sender, object e)
        {
            (sender as SystemColorPresenter).SystemColorChanged();
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
                typeof(SystemColorPresenter),
                new PropertyMetadata(false,
                new PropertyChangedCallback(OnUseCompactLayoutPropertyChanged)));

        private static void OnUseCompactLayoutPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            SystemColorPresenter control = d as SystemColorPresenter;
            control.UseCompactLayoutChanged();
        }

        public SystemColorPresenter()
        {
            InitializeComponent();
        }

        private void SystemColorChanged()
        {
            Bindings.Update();
        }

        private void OpenInfoTeachingTipButton_Click(object sender, RoutedEventArgs e)
        {
            TeachingTip teachingTip = Resources["InfoTeachingTip"] as TeachingTip;
            teachingTip.Content = new SystemColorInformation(SystemColor);
            teachingTip.Target = OpenInfoTeachingTipButton;
            teachingTip.IsOpen = true;

            teachingTip.Subtitle = "";
        }
        private void UseCompactLayoutChanged()
        {
            if (UseCompactLayout)
            {
                VisualStateManager.GoToState(this, "CompactLayout", false);
                ToolTipService.SetToolTip(this, "Color: " + SystemColor.Key);
            }
            else
            {
                VisualStateManager.GoToState(this, "NormalLayout", false);
                ToolTipService.SetToolTip(this, null);
            }
        }
    }
}
