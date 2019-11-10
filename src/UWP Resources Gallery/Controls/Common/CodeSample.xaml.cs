using ColorCode;
using ColorCode.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using UWPResourcesGallery.Common;
using Windows.ApplicationModel.DataTransfer;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace UWPResourcesGallery.Controls.Common
{
    public sealed partial class CodeSample : UserControl
    {

        #region Code property
        public static readonly DependencyProperty CodeProperty =
            DependencyProperty.Register(
                "Code",
                typeof(string),
                typeof(CodeSample),
                new PropertyMetadata(default(string), new PropertyChangedCallback(OnCodeDependencyPropertyChanged)));

        public string Code
        {
            get
            {
                return (string)GetValue(CodeProperty);
            }
            set
            {
                SetValue(CodeProperty, value);
                CodeChanged();
            }
        }

        private static void OnCodeDependencyPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var sampleObject = (d as CodeSample);
            sampleObject.CodeChanged();
        }

        #endregion

        #region IsSyntaxHighlightingEnabled

        public bool IsSyntaxHighlightingEnabled
        {
            get
            {
                return (bool)GetValue(IsSyntaxHighlightingEnabledProperty);
            }
            set
            {
                SetValue(IsSyntaxHighlightingEnabledProperty, value);
                CodeChanged();
            }
        }

        public static readonly DependencyProperty IsSyntaxHighlightingEnabledProperty =
            DependencyProperty.Register(
                "IsSyntaxHighlightingEnabled",
                typeof(bool),
                typeof(CodeSample),
                new PropertyMetadata(false, new PropertyChangedCallback(OnCodeDependencyPropertyChanged)));
        #endregion

        public CodeSample()
        {
            this.InitializeComponent();
        }

        private void CodeChanged()
        {
            CodeBlock.Blocks.Clear();
            if(Code == null)
            {
                return;
            }
            if (IsSyntaxHighlightingEnabled)
            {
                var formatter = new RichTextBlockFormatter(ThemeHelper.AppTheme);
                if (ThemeHelper.IsDarkTheme())
                {
                    UpdateFormatterDarkThemeColors(formatter);
                }
                formatter.FormatRichTextBlock(this.Code, Languages.Xml, CodeBlock);
            }
            else
            {
                Run r = new Run
                {
                    Text = Code
                };
                Paragraph p = new Paragraph();
                p.Inlines.Add(r);
                CodeBlock.Blocks.Add(p);
            }
        }

        private void UpdateFormatterDarkThemeColors(RichTextBlockFormatter formatter)
        {
            // Replace the default dark theme resources with ones that more closely align to VS Code dark theme.
            formatter.Styles.Remove(formatter.Styles[ScopeName.XmlAttribute]);
            formatter.Styles.Remove(formatter.Styles[ScopeName.XmlAttributeQuotes]);
            formatter.Styles.Remove(formatter.Styles[ScopeName.XmlAttributeValue]);
            formatter.Styles.Remove(formatter.Styles[ScopeName.HtmlComment]);
            formatter.Styles.Remove(formatter.Styles[ScopeName.XmlDelimiter]);
            formatter.Styles.Remove(formatter.Styles[ScopeName.XmlName]);

            formatter.Styles.Add(new ColorCode.Styling.Style(ScopeName.XmlAttribute)
            {
                Foreground = "#FF87CEFA",
                ReferenceName = "xmlAttribute"
            });
            formatter.Styles.Add(new ColorCode.Styling.Style(ScopeName.XmlAttributeQuotes)
            {
                Foreground = "#FFFFA07A",
                ReferenceName = "xmlAttributeQuotes"
            });
            formatter.Styles.Add(new ColorCode.Styling.Style(ScopeName.XmlAttributeValue)
            {
                Foreground = "#FFFFA07A",
                ReferenceName = "xmlAttributeValue"
            });
            formatter.Styles.Add(new ColorCode.Styling.Style(ScopeName.HtmlComment)
            {
                Foreground = "#FF6B8E23",
                ReferenceName = "htmlComment"
            });
            formatter.Styles.Add(new ColorCode.Styling.Style(ScopeName.XmlDelimiter)
            {
                Foreground = "#FF808080",
                ReferenceName = "xmlDelimiter"
            });
            formatter.Styles.Add(new ColorCode.Styling.Style(ScopeName.XmlName)
            {
                Foreground = "#FF5F82E8",
                ReferenceName = "xmlName"
            });
        }

        private void Copy_Click(object sender, RoutedEventArgs e)
        {
            DataPackage package = new DataPackage();
            package.SetText(this.Code);
            Clipboard.SetContent(package);
        }
    }
}
