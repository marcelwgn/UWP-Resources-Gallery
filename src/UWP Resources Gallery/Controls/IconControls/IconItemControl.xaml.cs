using UWPResourcesGallery.Models.Icon;
using System;
using System.Diagnostics;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;

namespace UWPResourcesGallery.Controls.IconControls
{
    public partial class IconItemControl : UserControl
    {

        #region IconItem property
        public static readonly DependencyProperty IconProperty =
            DependencyProperty.Register(
                "Icon",
                typeof(IconItem),
                typeof(IconItemControl),
                new PropertyMetadata(default(IconItem), new PropertyChangedCallback(OnIconDependencyPropertyChanged)));

        public IconItem Icon
        {
            get
            {
                return (IconItem)GetValue(IconProperty);
            }
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
        #endregion

        public IconItemControl()
        {
            this.InitializeComponent();
        }

        private void IconChanged()
        {
            this.Bindings.Update();
        }
    }
}
