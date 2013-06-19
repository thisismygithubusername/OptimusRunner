using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MbUnit.Framework;
using Twitter.Pages.Base;
using Twitter.Pages.LoggedInPages.Home;
using Twitter.Tests.Config;

namespace Twitter.Tests.LoggedIn
{
    
    public abstract class LoggedInTestSuite : AbstractTestSuite
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
        }

    }
}
