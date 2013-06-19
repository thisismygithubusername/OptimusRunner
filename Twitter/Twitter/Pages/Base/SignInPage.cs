using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bumblebee.Implementation;
using Bumblebee.Interfaces;
using Bumblebee.Setup;
using OpenQA.Selenium;

namespace Twitter.Pages.Base
{
    public class SignInPage : WebBlock 
    {
        public SignInPage(Session session) : base(session)
        {
           
        }

        public ITextField<SignInPage> Username
        {
            get { return new TextField<SignInPage>(this, By.Id("signin-email")); }
        }

        public ITextField<SignInPage> Password
        {
            get { return new TextField<SignInPage>(this, By.Id("signin-password")); }
        }

        public ICheckbox<SignInPage> RememberMe
        {
            get { return new Checkbox<SignInPage>(this, By.Name("remember_me")); }
        }

        public IClickable SignInButton
        {
            get { return new Clickable(this, By.XPath(".//button[@class='submit btn primary-btn flex-table-btn js-submit']")); }
        }
    }

    public class SignUpBlock : SignInPage
    {
        public SignUpBlock(Session session) : base(session)
        {
        }

        public ITextField<SignInPage> SignupName
        {
            get { return new TextField<SignInPage>(this, By.Id("signup-user-name")); }
        }

        public ITextField<SignInPage> SignupEmail
        {
            get { return new TextField<SignInPage>(this, By.Id("signup-user-email")); }
        }
        
        public ITextField<SignInPage> SignUpPassword 
        {
            get { return new TextField<SignInPage>(this, By.Id("signup-user-password")); }
        }

        public IClickable SignUpButton
        {
            get { return new Clickable(this, By.ClassName("signup-btn")); }
        }
    }
}
