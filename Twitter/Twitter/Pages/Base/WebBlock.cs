using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Bumblebee.Implementation;
using Bumblebee.Setup;
using Bumblebee.Extensions;
using OpenQA.Selenium;

namespace Twitter.Pages.Base
{
    public class WebBlock : Block
    {
        public WebBlock(Session session) : base(session)
        {
            Thread.Sleep(500);
            Session.Driver.SwitchTo().DefaultContent();
            Tag = Session.Driver.FindElement(By.TagName("body"));
        }
    }
}
