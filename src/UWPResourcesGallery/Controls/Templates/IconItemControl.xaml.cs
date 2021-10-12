using System;
using UWPResourcesGallery.ResourceModel.Icons;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace UWPResourcesGallery.Controls.Templates
{
    public sealed partial class IconItemControl : UserControl
    {

        public UIElement IconViewPresenter => IconView;

        public static readonly DependencyProperty IconProperty =
            DependencyProperty.Register(
                "Icon",
                typeof(IconItem),
                typeof(IconItemControl),
                new PropertyMetadata(default(IconItem), new PropertyChangedCallback(OnIconDependencyPropertyChanged)));

        public IconItem Icon
        {
            get => (IconItem)GetValue(IconProperty);
            set
            {
                SetValue(IconProperty, value);
                IconChanged();
            }
        }

        private static void OnIconDependencyPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            IconItemControl control = d as IconItemControl;
            control.IconChanged();
        }

        public bool UseCompactLayout
        {
            get { return (bool)GetValue(UseCompactLayoutProperty); }
            set { SetValue(UseCompactLayoutProperty, value); }
        }

        // Using a DependencyProperty as the backing store for UseCompactLayout.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty UseCompactLayoutProperty =
            DependencyProperty.Register(
                "UseCompactLayout",
                typeof(bool),
                typeof(IconItemControl),
                new PropertyMetadata(false,
                new PropertyChangedCallback(OnUseCompactLayoutPropertyChanged)));

        private static void OnUseCompactLayoutPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            IconItemControl control = d as IconItemControl;
            control.UseCompactLayoutChanged();
        }
        public IconItemControl()
        {
            InitializeComponent();
        }

        private void IconChanged()
        {
            Bindings.Update();
        }

        private void UseCompactLayoutChanged()
        {
            if (UseCompactLayout)
            {
                VisualStateManager.GoToState(this, "CompactLayout", false);
                ToolTipService.SetToolTip(this, "Icon: " + Icon.Name);
            }
            else
            {
                VisualStateManager.GoToState(this, "NormalLayout", false);
                ToolTipService.SetToolTip(this, null);
            }
        }
    }
}
