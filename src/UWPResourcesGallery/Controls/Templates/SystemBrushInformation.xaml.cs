using System;
using UWPResourcesGallery.Model.Brushes;
using Windows.UI.Xaml.Controls;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace UWPResourcesGallery.Controls.Templates
{
    public sealed partial class SystemBrushInformation : UserControl
    {
        private readonly SystemBrush SystemBrush;

        public SystemBrushInformation(SystemBrush systemBrush)
        {
            SystemBrush = systemBrush ?? throw new ArgumentNullException(nameof(systemBrush));
            
            InitializeComponent();

            UpdateSnippets();
        }

        private void UpdateSnippets()
        {
            XAMLDefinitionCodeSample.Code = SystemBrush.XAMLDefinition;
            ThemeresourceCodeSample.Code = SystemBrush.ThemeResourceString;
            UpdateLayout();
        }
    }
}
