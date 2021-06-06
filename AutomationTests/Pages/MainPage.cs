using Framework;
using Framework.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System.Collections.Generic;

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
        private IEnumerable<IWebElement> DropDownSections => Driver.FindElementsByXPath("//select[@id = 'searchDropdownBox']//option");

        public string PageTitle => Driver.Title;

        public string PageUrl => Driver.Url;

        public void ClickSearchButton() => BtnSearchSubmit.Click();

        public void OpenMainPage()
        {
            GoTo("https://www.amazon.co.uk/");
        }

        public void ChooseSection(string section)
        {
            DropDownSections.GetElementFromCollection(section).Click();
        }

        public void AddTextInSearchField(string text)
        {
            TxtSearchField.Clear();
            TxtSearchField.SendKeys(text);
        }

        public void SearchItem(string searchText)
        {
            AddTextInSearchField(searchText);

            ClickSearchButton();
        }

        public CartPage OpenBasket()
        {
            LnkBasket.Click();

            return new CartPage(Driver);
        }
    }
}
