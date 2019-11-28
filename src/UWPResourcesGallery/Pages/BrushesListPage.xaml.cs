using UWPResourcesGallery.Model.Brush;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238
 
namespace UWPResourcesGallery.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class BrushesListPages : Page
    {
      
        private readonly BrushItemSource source = new BrushItemSource();

        public BrushesListPages()
        {
            InitializeComponent();
            SystemBrushesPresenter.ItemsSource = source.FilteredItems;
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs args)
        {
            source.Filter((sender as TextBox).Text);
        }

    }
}
