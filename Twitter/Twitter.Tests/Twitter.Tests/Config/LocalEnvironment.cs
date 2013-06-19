using Bumblebee.Setup;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Twitter.Tests.Config
{
    public class LocalEnvironment :IDriverEnvironment 
    {
        public IWebDriver CreateWebDriver()
        {
            IWebDriver driver = new ChromeDriver(@"C:\Users\jorge.salcedo\Documents\ChromeDriver\");
            driver.Manage().Window.Maximize();
            return driver;
        }

    }
}
