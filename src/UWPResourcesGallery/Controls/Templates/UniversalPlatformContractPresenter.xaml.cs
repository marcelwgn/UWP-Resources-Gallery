using UWPResourcesGallery.Model.WindowsVersionContracts;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace UWPResourcesGallery.Controls.Templates
{
    public sealed partial class UniversalPlatformContractPresenter : UserControl
    {

        private bool isExpanded = false;

        public UniversalPlatformContract Contract
        {
            get { return (UniversalPlatformContract)GetValue(ContractProperty); }
            set { SetValue(ContractProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Contract. This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ContractProperty =
            DependencyProperty.Register("Contract", typeof(UniversalPlatformContract), typeof(UniversalPlatformContractPresenter), new PropertyMetadata(null));

        public UniversalPlatformContractPresenter()
        {
            this.InitializeComponent();
            VisualStateManager.GoToState(this, "Collapsed", false);
        }

        private void RootButton_Click(object sender, RoutedEventArgs e)
        {
            if(!isExpanded)
            {
                VisualStateManager.GoToState(this, "Expanded",false);
            }
            else
            {
                VisualStateManager.GoToState(this, "Collapsed", false);
            }
            isExpanded = !isExpanded;
        }
    }
}
