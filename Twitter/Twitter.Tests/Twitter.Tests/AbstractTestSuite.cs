using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MbUnit.Framework;
using Twitter.Pages.Base;
using Twitter.Tests.Config;

namespace Twitter.Tests
{
    public abstract class AbstractTestSuite
    {
        private readonly ThreadLocal<TwitterSession> _threadLocalSession = new ThreadLocal<TwitterSession>();

        protected TwitterSession Session 
        { 
            get { return _threadLocalSession.Value; }
            private set { _threadLocalSession.Value = value; }
        }

        [SetUp]
        public virtual void SetUp()
        {
            Session = new TwitterSession(new LocalEnvironment());
            Session.GoToSite<SignInPage>();
        }

        [TearDown]
        public void TearDown()
        {
            Session.End();
        }


    }
}
