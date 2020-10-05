using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UnitTesting.AppContainer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UWPResourcesGallery.Controls.Templates;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Automation.Peers;
using Windows.UI.Xaml.Controls;

namespace UWPResourcesGallery.Controls.Tests.UITests
{
    [TestClass]
    public class UniversalPlatformContractPresenterTests
    {

        [UITestMethod]
        public void VerifyExpandAndCollapseWorkCorrectly()
        {
            var presenter = (UniversalPlatformContractPresenter)ControlsTestPage.Instance.FindName("TestContractPresenter");
            var rootButton = new ButtonAutomationPeer((Button)presenter.FindName("RootButton"));
            var codeSample = (StackPanel)presenter.FindName("SampleCodePanel");
            Assert.AreEqual(Visibility.Collapsed, codeSample.Visibility);

            rootButton.Invoke();
            
            codeSample = (StackPanel)presenter.FindName("SampleCodePanel");
            Assert.AreEqual(Visibility.Visible, codeSample.Visibility);

            rootButton.Invoke();

            codeSample = (StackPanel)presenter.FindName("SampleCodePanel");
            Assert.AreEqual(Visibility.Collapsed, codeSample.Visibility);
        }
    }
}
