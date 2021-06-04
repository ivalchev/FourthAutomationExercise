using Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace AutomationTests.Pages
{
    public class MainPage : BasePage
    {
        public MainPage(RemoteWebDriver driver)
            : base(driver)
        {
        }

        private IWebElement TxtSearchField => Driver.FindElementById("twotabsearchtextbox");
        private IWebElement BtnSearchSubmit => Driver.FindElementById("nav-search-submit-button");
        private IWebElement LnkBasket => Driver.FindElementById("nav-cart");

        public string PageTitle => Driver.Title;

        public string PageUrl => Driver.Url;

        public void OpenMainPage()
        {
            Driver.Navigate().GoToUrl("https://www.amazon.co.uk/");
        }
    }
}
