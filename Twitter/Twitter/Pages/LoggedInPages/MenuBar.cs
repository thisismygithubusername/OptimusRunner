using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bumblebee.Implementation;
using Bumblebee.Interfaces;
using Bumblebee.Setup;
using OpenQA.Selenium;
using Twitter.Pages.Base;
using Twitter.Pages.LoggedInPages.Connect;
using Twitter.Pages.LoggedInPages.Discover;
using Twitter.Pages.LoggedInPages.Home;
using Twitter.Pages.LoggedInPages.Profile;

namespace Twitter.Pages.LoggedInPages
{
    public class MenuBar : WebBlock 
    {
        public MenuBar(Session session) : base(session)
        {
        }

        public IClickable<HomePage> Home
        {
            get { return new Clickable<HomePage>(this, By.Id("global-nav-home")); }
        }

        public IClickable<ConnectPage> Connect
        {
            get { return new Clickable<ConnectPage>(this, By.ClassName("nav-people")); }
        }

        public IClickable<DiscoverPage> Discover
        {
            get { return new Clickable<DiscoverPage>(this, By.ClassName("topics")); }
        }

        public IClickable<MyProfilePage> Me
        {
            get { return new Clickable<MyProfilePage>(this, By.ClassName("profile")); }
        }

    }
}
