using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bumblebee.Setup;
using OpenQA.Selenium;

namespace Twitter.Pages.LoggedInPages.Connect
{
    public class ConnectPage : LoggedInPage
    {
        public ConnectPage(Session session) : base(session)
        {
            Tag = GetElement(By.ClassName("wrapper-connect"));
        }

        
    }
}
