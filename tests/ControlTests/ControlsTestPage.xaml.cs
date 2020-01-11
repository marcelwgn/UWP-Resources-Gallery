﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using UWPResourcesGallery.Controls.Templates;
using UWPResourcesGallery.Model.Colors;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace ControlTests
{


    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ControlsTestPage : Page
    {

        public static ControlsTestPage Instance { get; private set; }
        
        public ControlsTestPage()
        {
            InitializeComponent();
            Instance = this;


            var systemColor = new SystemColor("SystemAccentColor","colorName","colorLightHex","colorDarkHex");
            SystemColorInformationPanel.Children.Add(new SystemColorInformation(systemColor));
            SystemColorInformationPanel.UpdateLayout();
        }
    }
}
