using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UnitTesting.AppContainer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWPResourcesGallery.Controls.Common;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Automation.Peers;
using Windows.UI.Xaml.Automation.Provider;
using Windows.UI.Xaml;
using Windows.UI.Core;
using Windows.UI.ViewManagement;

namespace ControlTests.Tests
{
    [TestClass]
    public class CodeSampleTests
    {

        [UITestMethod]
        public void VerifyRenderedText()
        {
            var codeSampleNormal = (CodeSample)ControlsTestPage.Instance.FindName("CodeSampleNormal");
            var codeText = (RichTextBlock)codeSampleNormal.FindName("CodeBlock");
            codeText.SelectAll();

            Assert.AreEqual("Code", codeText.SelectedText);

            var codeSampleHighlightingEnabled = (CodeSample)ControlsTestPage.Instance.FindName("CodeSampleWithHighlighting");
            codeText = (RichTextBlock)codeSampleHighlightingEnabled.FindName("CodeBlock");
            codeText.SelectAll();

            Assert.AreEqual("<Code />", codeText.SelectedText);
        }

        [UITestMethod]
        public void CopiesTextCorrectly()
        {
            try
            {
                var codeSampleNormal = (CodeSample)ControlsTestPage.Instance.FindName("CodeSampleNormal");
                var copyButton = new ButtonAutomationPeer((Button)codeSampleNormal.FindName("CopyButton"));

                copyButton.Invoke();
                Assert.AreEqual("Code", GetClipBoardText());

                var codeSampleHighlightingEnabled = (CodeSample)ControlsTestPage.Instance.FindName("CodeSampleWithHighlighting");
                copyButton = new ButtonAutomationPeer((Button)codeSampleHighlightingEnabled.FindName("CopyButton"));

                copyButton.Invoke();

                Assert.AreEqual("<Code />", GetClipBoardText());
            }catch (UnauthorizedAccessException)
            {
                // Pasting to clipboard is not allowed while app is in background
#pragma warning disable CA1303 // Do not pass literals as localized parameters
                Console.WriteLine("Test CopiesTextCorrectly was not run as app is not in foreground");
#pragma warning restore CA1303 // Do not pass literals as localized parameters
            }
        }

        private static string GetClipBoardText(){
            var clipBoard = Windows.ApplicationModel.DataTransfer.Clipboard.GetContent();
            var task = clipBoard.GetTextAsync().AsTask();
            try
            {
                task.RunSynchronously();
            } catch(InvalidOperationException) { }
            return task.Result;
        }
    }
}
