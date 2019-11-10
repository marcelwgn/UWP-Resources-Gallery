using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace UWPResourcesGallery.Controls.Common
{
    public sealed partial class DualThemePresenter : UserControl
    {

        #region LightThemeContent property
        public FrameworkElement LightThemeContent
        {
            get
            {
                return (FrameworkElement)GetValue(LightThemeContentProperty);
            }
            set
            {
                SetValue(LightThemeContentProperty, value);
                ThemedContentChanged();
            }
        }
        public static DependencyProperty LightThemeContentProperty = DependencyProperty.Register(
                "LightThemeContent",
                typeof(FrameworkElement),
                typeof(DualThemePresenter),
                new PropertyMetadata(default(FrameworkElement), ThemedContentPropertyChanged)
            );
        #endregion

        #region DarkThemeContent property
        public FrameworkElement DarkThemeContent
        {
            get
            {
                return (FrameworkElement)GetValue(DarkThemeContentProperty);
            }
            set
            {
                SetValue(DarkThemeContentProperty, value);
                ThemedContentChanged();
            }
        }
        public static DependencyProperty DarkThemeContentProperty = DependencyProperty.Register(
                "LightThemeContent",
                typeof(FrameworkElement),
                typeof(DualThemePresenter),
                new PropertyMetadata(default(FrameworkElement), ThemedContentPropertyChanged)
            );
        #endregion
        public DualThemePresenter()
        {
            InitializeComponent();
        }

        private void ThemedContentChanged()
        {
            Bindings.Update();
        }

        public static void ThemedContentPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            (d as DualThemePresenter).ThemedContentChanged();
        }
    }
}
