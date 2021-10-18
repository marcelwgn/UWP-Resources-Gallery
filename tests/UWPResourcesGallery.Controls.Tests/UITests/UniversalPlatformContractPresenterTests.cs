using Microsoft.UI.Xaml.Automation.Peers;
using Microsoft.UI.Xaml.Controls;
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
            var expander = (Expander)presenter.FindName("RootExpander");
            var expanderPeer = new ExpanderAutomationPeer(expander);

            Assert.IsNotNull(expander.Header);
            Assert.IsNotNull(expander.Content);
            Assert.AreEqual(expanderPeer.ExpandCollapseState, Windows.UI.Xaml.Automation.ExpandCollapseState.Collapsed);
        }
    }
}
