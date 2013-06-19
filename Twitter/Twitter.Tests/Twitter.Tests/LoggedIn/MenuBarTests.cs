using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bumblebee.Setup;
using MbUnit.Framework;
using Twitter.Pages.Base;
using Twitter.Pages.LoggedInPages;
using Twitter.Pages.LoggedInPages.Home;
using Twitter.Tests.Config;

namespace Twitter.Tests.LoggedIn
{
 
    public class MenuBarTests : LoggedInTestSuite
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            Session.CurrentBlock<SignInPage>()
                   .Username.EnterText(AccountSettings.UserName)
                   .Password.EnterText(AccountSettings.Password)
                   .SignInButton.Click<HomePage>();
        }
        [Test]
        public void NavigatePages()
        {
            Session.CurrentBlock<HomePage>().MenuBar.Home.Click().MenuBar.Discover.Click().MenuBar.Connect.Click();
        }
    }
}
