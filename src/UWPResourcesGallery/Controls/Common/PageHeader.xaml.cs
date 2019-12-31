using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace UWPResourcesGallery.Controls.Common
{
    public sealed partial class PageHeader : UserControl
    {


        #region PageName property
        public string PageName
        {
            get { return (string)GetValue(PageNameProperty); }
            set { SetValue(PageNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PageName.
        public static readonly DependencyProperty PageNameProperty =
            DependencyProperty.Register("PageName", typeof(string), typeof(PageHeader), new PropertyMetadata(default(string)));
        #endregion

        #region PageDescription property
        public string PageDescription
        {
            get { return (string)GetValue(PageDescriptionProperty); }
            set { SetValue(PageDescriptionProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PageDescription.
        public static readonly DependencyProperty PageDescriptionProperty =
            DependencyProperty.Register("PageDescription", typeof(string), typeof(PageHeader), new PropertyMetadata(default(string)));
        #endregion

        public PageHeader()
        {
            InitializeComponent();
        }
    }
}
