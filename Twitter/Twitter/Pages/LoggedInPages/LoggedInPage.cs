using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bumblebee.Implementation;
using Bumblebee.Setup;
using OpenQA.Selenium;
using Twitter.Pages.Base;

namespace Twitter.Pages.LoggedInPages
{
    public class LoggedInPage : WebBlock  
    {
        public LoggedInPage(Session session) : base(session)
        {
            Tag = Session.Driver.FindElement(By.ClassName("logged-in"));
        }

        public MenuBar MenuBar
        {
            get  { return new MenuBar(Session);}
        }
        

    }

}
