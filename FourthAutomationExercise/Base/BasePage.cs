using OpenQA.Selenium;

namespace Framework
{
    public abstract class BasePage
    {
        protected BasePage(IWebDriver driver)
        {
            Driver = driver;
        }

        protected IWebDriver Driver { get; private set; }

        public void GoTo(string url)
        {
            Driver.Navigate().GoToUrl(url);
        }
    }
}
