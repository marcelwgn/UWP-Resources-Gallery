using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using UWPResourcesGallery.Model.WindowsVersionContracts;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace UWPResourcesGallery.Controls.Templates
{

    public sealed partial class UniversalPlatformVersionPresenter : UserControl
    {
        public UniversalPlatformVersion UWPVersion
        {
            get { return (UniversalPlatformVersion)GetValue(UWPVersionProperty); }
            set { SetValue(UWPVersionProperty, value); }
        }

        // Using a DependencyProperty as the backing store for UWPVersion.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty UWPVersionProperty =
            DependencyProperty.Register("UWPVersion", typeof(UniversalPlatformVersion), typeof(UniversalPlatformVersionPresenter), new PropertyMetadata(default(UniversalPlatformVersion)));


        public UniversalPlatformVersionPresenter()
        {
            this.InitializeComponent();
        }
    }
}
