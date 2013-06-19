using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bumblebee.Setup;
using OpenQA.Selenium;

namespace Twitter.Pages.LoggedInPages.Discover
{
    public class DiscoverPage : LoggedInPage
    {
        public DiscoverPage(Session session) : base(session)
        {
            Tag = GetElement(By.ClassName("wrapper-discover"));
        }

    }
}
