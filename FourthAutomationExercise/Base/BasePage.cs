using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace Framework
{
    public abstract class BasePage
    {
        protected BasePage(RemoteWebDriver driver)
        {
            Driver = driver;
        }

        protected RemoteWebDriver Driver { get; private set; }

        public void GoTo(string url)
        {
            Driver.Navigate().GoToUrl(url);
        }
    }
}
