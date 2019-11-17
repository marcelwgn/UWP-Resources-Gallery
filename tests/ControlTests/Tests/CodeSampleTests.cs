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
            var codeSampleNormal = (CodeSample)ControlsTestPage.Instance.FindName("CodeSampleNormal");
            var copyButton = new ButtonAutomationPeer((Button)codeSampleNormal.FindName("CopyButton"));

            copyButton.Invoke();
            Assert.AreEqual("Code", GetClipBoardText());

            var codeSampleHighlightingEnabled = (CodeSample)ControlsTestPage.Instance.FindName("CodeSampleWithHighlighting");
            copyButton = new ButtonAutomationPeer((Button)codeSampleHighlightingEnabled.FindName("CopyButton"));

            copyButton.Invoke();

            Assert.AreEqual("<Code />", GetClipBoardText());
        }

        private static string GetClipBoardText(){
            var clipBoard = Windows.ApplicationModel.DataTransfer.Clipboard.GetContent();
            var task = clipBoard.GetTextAsync().AsTask();
            try
            {
                task.RunSynchronously();
            } catch(InvalidOperationException exc) { }
            return task.Result;
        }
    }
}
