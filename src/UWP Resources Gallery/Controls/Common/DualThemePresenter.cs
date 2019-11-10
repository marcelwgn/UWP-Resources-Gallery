using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace UWPResourcesGallery.Controls.Common
{
    public sealed partial class DualThemePresenter : UserControl
    {

        #region LightThemeContent property
        public FrameworkElement LightThemeContent
        {
            get
            {
                return (FrameworkElement)GetValue(LightThemeContentProperty);
            }
            set
            {
                SetValue(LightThemeContentProperty, value);
                ThemedContentChanged();
            }
        }
        public static DependencyProperty LightThemeContentProperty = DependencyProperty.Register(
                "LightThemeContent",
                typeof(FrameworkElement),
                typeof(DualThemePresenter),
                new PropertyMetadata(default(FrameworkElement), ThemedContentPropertyChanged)
            );
        #endregion

        #region DarkThemeContent property
        public FrameworkElement DarkThemeContent
        {
            get
            {
                return (FrameworkElement)GetValue(DarkThemeContentProperty);
            }
            set
            {
                SetValue(DarkThemeContentProperty, value);
                ThemedContentChanged();
            }
        }
        public static DependencyProperty DarkThemeContentProperty = DependencyProperty.Register(
                "LightThemeContent",
                typeof(FrameworkElement),
                typeof(DualThemePresenter),
                new PropertyMetadata(default(FrameworkElement), ThemedContentPropertyChanged)
            );
        #endregion
        public DualThemePresenter()
        {
            this.InitializeComponent();
        }

        private void ThemedContentChanged()
        {
            this.Bindings.Update();
        }
        
        public static void ThemedContentPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            (d as DualThemePresenter).ThemedContentChanged();
        }
    }
}
