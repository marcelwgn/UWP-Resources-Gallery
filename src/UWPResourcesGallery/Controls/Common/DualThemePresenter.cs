﻿using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace UWPResourcesGallery.Controls.Common
{
    public sealed partial class DualThemePresenter : UserControl
    {

        #region LightThemeContent property
        public FrameworkElement LightThemeContent
        {
            get => (FrameworkElement)GetValue(LightThemeContentProperty);
            set
            {
                SetValue(LightThemeContentProperty, value);
                ThemedContentChanged();
            }
        }
        public static readonly DependencyProperty LightThemeContentProperty = DependencyProperty.Register(
                "LightThemeContent",
                typeof(FrameworkElement),
                typeof(DualThemePresenter),
                new PropertyMetadata(default(FrameworkElement), ThemedContentPropertyChanged)
            );
        #endregion

        #region DarkThemeContent property
        public FrameworkElement DarkThemeContent
        {
            get => (FrameworkElement)GetValue(DarkThemeContentProperty);
            set
            {
                SetValue(DarkThemeContentProperty, value);
                ThemedContentChanged();
            }
        }
        public static readonly DependencyProperty DarkThemeContentProperty = DependencyProperty.Register(
                "DarkThemeContent",
                typeof(FrameworkElement),
                typeof(DualThemePresenter),
                new PropertyMetadata(default(FrameworkElement), ThemedContentPropertyChanged)
            );
        #endregion

        #region ContentOrientation property
        public Orientation ContentOrientation
        {
            get => (Orientation)GetValue(ContentOrientationProperty);
            set => SetValue(ContentOrientationProperty, value);
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ContentOrientationProperty =
            DependencyProperty.Register("ContentOrientation", typeof(Orientation), typeof(DualThemePresenter), new PropertyMetadata(0));
        #endregion

        public DualThemePresenter()
        {
            InitializeComponent();
        }

        private void ThemedContentChanged()
        {
            Bindings.Update();
        }

        public static void ThemedContentPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d == null)
            {
                return;
            }
            (d as DualThemePresenter).ThemedContentChanged();
        }
    }
}
