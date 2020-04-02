using UWPResourcesGallery.Controls.Templates;
using UWPResourcesGallery.Model.Colors;
using UWPResourcesGallery.Model.WindowsVersionContracts;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace ControlTests
{


    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ControlsTestPage : Page
    {

        public static ControlsTestPage Instance { get; private set; }

        private UniversalPlatformContract universalPlatformContract = new UniversalPlatformContract("MyContract", "1.0");

        public ControlsTestPage()
        {
            InitializeComponent();
            Instance = this;


            SystemColor systemColor = new SystemColor("SystemAccentColor", "colorName", "colorLightHex", "colorDarkHex");
            SystemColorInformationPanel.Children.Add(new SystemColorInformation(systemColor));
            SystemColorInformationPanel.UpdateLayout();


        }
    }
}
