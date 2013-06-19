using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bumblebee.Setup;
using OpenQA.Selenium;

namespace Twitter.Pages.LoggedInPages.Profile
{
    public class MyProfilePage : LoggedInPage
    {
        public MyProfilePage(Session session) : base(session)
        {
            Tag = GetElement(By.ClassName("wrapper-profile"));
        }
    }
}
