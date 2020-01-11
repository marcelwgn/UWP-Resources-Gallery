using Microsoft.UI.Xaml.Controls;
using UWPResourcesGallery.Model.Colors;
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
            get
            {
                return (SystemColor)GetValue(SystemColorItemDependencyProperty);
            }
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
            var teachingTip = Resources["InfoTeachingTip"] as TeachingTip;
            teachingTip.Content = new SystemColorInformation(SystemColor);
            teachingTip.Target = OpenInfoTeachingTipButton;
            teachingTip.IsOpen = true;

            teachingTip.Subtitle = "";
        }
    }
}
