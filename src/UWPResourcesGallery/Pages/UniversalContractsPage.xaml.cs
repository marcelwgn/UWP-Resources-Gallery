using Microsoft.AppCenter.Analytics;
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using UWPResourcesGallery.Model.WindowsVersionContracts;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace UWPResourcesGallery.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class UniversalContractsPage : Page
    {
        private readonly UniversalPlatformVersionSource source = new UniversalPlatformVersionSource();

        public UniversalPlatformVersion SelectedItem
        {
            get { return (UniversalPlatformVersion)GetValue(SelectedItemProperty); }
            set { SetValue(SelectedItemProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SelectedItem.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedItemProperty =
            DependencyProperty.Register("SelectedItem", typeof(UniversalPlatformVersion), typeof(UniversalContractsPage), new PropertyMetadata(default(UniversalPlatformVersion)));

        public UniversalContractsPage()
        {
            this.InitializeComponent();
            SelectedItem = source.FilteredItems[0];
            UniversalVersionsPresenterContainer.ItemsSource = source.FilteredItems;
            UniversalVersionsPresenterContainer.SelectedItem = source.FilteredItems[0];
            Analytics.TrackEvent("Visited: UniversalContractsPage");
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs args)
        {
            source.Filter((sender as TextBox).Text);
            if(source.FilteredItems.Count > 0)
            {
                EmptySearchLabel.Visibility = Visibility.Collapsed;
                SelectedItemScroller.Visibility = Visibility.Visible;
                
                SelectedItem = source.FilteredItems[0];
                UniversalVersionsPresenterContainer.SelectedItem = source.FilteredItems[0];

            }
            else
            {
                EmptySearchLabel.Visibility = Visibility.Visible;
                SelectedItemScroller.Visibility = Visibility.Collapsed;
            }
        }

        private void UniveralsVersionsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(e.AddedItems.Count > 0)
            {
                SelectedItem = e.AddedItems[0] as UniversalPlatformVersion;
            }
        }
    }
}
