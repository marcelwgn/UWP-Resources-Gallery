using ColorCode;
using ColorCode.Common;
using UWPResourcesGallery.Common;
using Windows.ApplicationModel.DataTransfer;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Documents;

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
            get => (string)GetValue(CodeProperty);
            set
            {
                SetValue(CodeProperty, value);
                CodeChanged();
            }
        }

        private static void OnCodeDependencyPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            CodeSample sampleObject = (d as CodeSample);
            sampleObject.CodeChanged();
        }

        #endregion

        #region IsSyntaxHighlightingEnabled

        public bool IsSyntaxHighlightingEnabled
        {
            get => (bool)GetValue(IsSyntaxHighlightingEnabledProperty);
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


        #region SyteaxmLanguage property
        public ILanguage SyntaxLanguage
        {
            get { return (ILanguage)GetValue(SyntaxLanguageProperty); }
            set { SetValue(SyntaxLanguageProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SyntaxLanguage.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SyntaxLanguageProperty =
            DependencyProperty.Register("SyntaxLanguage", typeof(Languages), typeof(ILanguage), new PropertyMetadata(0));
        #endregion


        public CodeSample()
        {
            InitializeComponent();
            // Setting default syntax language
            SyntaxLanguage = Languages.Xml;
        }

        private void CodeChanged()
        {
            CodeBlock.Blocks.Clear();
            if (Code == null)
            {
                return;
            }
            if (IsSyntaxHighlightingEnabled)
            {
                RichTextBlockFormatter formatter = new RichTextBlockFormatter(ThemeHelper.AppTheme);
                if (ThemeHelper.IsDarkTheme())
                {
                    UpdateFormatterDarkThemeColors(formatter);
                    if(SyntaxLanguage != Languages.Xml)
                    {
                        formatter = new RichTextBlockFormatter(ElementTheme.Dark);
                    }
                }
                formatter.FormatRichTextBlock(Code, SyntaxLanguage, CodeBlock);
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

        private static void UpdateFormatterDarkThemeColors(RichTextBlockFormatter formatter)
        {
            // Replace the default dark theme resources with ones that more closely align to VS Code dark theme.
            // CS
            formatter.Styles.Remove(formatter.Styles[ScopeName.ClassName]);
            formatter.Styles.Add(new ColorCode.Styling.Style(ScopeName.ClassName)
            {
                Foreground = "#FF3AC6AD",
                ReferenceName = "className"
            });


            // XAML
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
            package.SetText(Code);
            Clipboard.SetContent(package);
        }
    }
}
