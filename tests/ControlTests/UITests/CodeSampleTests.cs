using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UnitTesting.AppContainer;
using System;
using System.Threading.Tasks;
using UWPResourcesGallery.Controls.Common;
using Windows.UI.Xaml.Automation.Peers;
using Windows.UI.Xaml.Controls;

namespace ControlTests.UITests
{
    [TestClass]
    public class CodeSampleTests
    {

        [UITestMethod]
        public void VerifyRenderedText()
        {
            CodeSample codeSampleNormal = (CodeSample)ControlsTestPage.Instance.FindName("CodeSampleNormal");
            RichTextBlock codeText = (RichTextBlock)codeSampleNormal.FindName("CodeBlock");
            codeText.SelectAll();

            Assert.AreEqual("Code", codeText.SelectedText);

            CodeSample codeSampleHighlightingEnabled = (CodeSample)ControlsTestPage.Instance.FindName("CodeSampleWithHighlighting");
            codeText = (RichTextBlock)codeSampleHighlightingEnabled.FindName("CodeBlock");
            codeText.SelectAll();

            Assert.AreEqual("<Code />", codeText.SelectedText);
        }

        [UITestMethod]
        public void CopiesTextCorrectly()
        {
            try
            {
                CodeSample codeSampleNormal = (CodeSample)ControlsTestPage.Instance.FindName("CodeSampleNormal");
                ButtonAutomationPeer copyButton = new ButtonAutomationPeer((Button)codeSampleNormal.FindName("CopyButton"));

                copyButton.Invoke();
                Assert.AreEqual("Code", GetClipBoardText());

                CodeSample codeSampleHighlightingEnabled = (CodeSample)ControlsTestPage.Instance.FindName("CodeSampleWithHighlighting");
                copyButton = new ButtonAutomationPeer((Button)codeSampleHighlightingEnabled.FindName("CopyButton"));

                copyButton.Invoke();

                Assert.AreEqual("<Code />", GetClipBoardText());
            }
            catch (UnauthorizedAccessException)
            {
                // Pasting to clipboard is not allowed while app is in background
#pragma warning disable CA1303 // Do not pass literals as localized parameters
                Console.WriteLine("Test CopiesTextCorrectly was not run as app is not in foreground");
#pragma warning restore CA1303 // Do not pass literals as localized parameters
            }
        }

        private static string GetClipBoardText()
        {
            Windows.ApplicationModel.DataTransfer.DataPackageView clipBoard = Windows.ApplicationModel.DataTransfer.Clipboard.GetContent();
            Task<string> task = clipBoard.GetTextAsync().AsTask();
            try
            {
                task.RunSynchronously();
            }
            catch (InvalidOperationException) { }
            return task.Result;
        }
    }
}
