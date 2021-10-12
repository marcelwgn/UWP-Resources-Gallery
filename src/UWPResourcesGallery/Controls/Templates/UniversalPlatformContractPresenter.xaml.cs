using UWPResourcesGallery.ResourceModel.WindowsVersionContracts;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace UWPResourcesGallery.Controls.Templates
{
    public sealed partial class UniversalPlatformContractPresenter : UserControl
    {

        public string ContractName => Contract?.Name + ", Version=" + Contract?.Version;

        public UniversalPlatformContract Contract
        {
            get { return (UniversalPlatformContract)GetValue(ContractProperty); }
            set { 
                SetValue(ContractProperty, value);
            }
        }

        // Using a DependencyProperty as the backing store for Contract. This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ContractProperty =
            DependencyProperty.Register("Contract", typeof(UniversalPlatformContract), 
                typeof(UniversalPlatformContractPresenter), 
                new PropertyMetadata(null, new PropertyChangedCallback(OnContractChanged)));

        private static void OnContractChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is UniversalPlatformContractPresenter presenter)
            {
                presenter.ContractNamePresenter.Text = presenter.ContractName;
            }
        }

        public UniversalPlatformContractPresenter()
        {
            this.InitializeComponent();
        }
    }
}
