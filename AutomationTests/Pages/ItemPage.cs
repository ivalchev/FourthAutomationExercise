using AutomationTests.Pages.Basket;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace AutomationTests.Pages
{
    public class ItemPage : MainPage
    {
        public ItemPage(RemoteWebDriver driver)
            : base(driver)
        {
        }

        private IWebElement TxtProductTitle => Driver.FindElementById("productTitle");
        private IWebElement LnkProductBadge => Driver.FindElementByClassName("badge-link");
        private IWebElement TxtProductPrice => Driver.FindElementByXPath("//span[@class ='a-size-base a-color-price a-color-price']");
        private IWebElement TxtProductType => Driver.FindElementById("productSubtitle");
        private IWebElement BtnAddToBasket => Driver.FindElementById("add-to-cart-button");

        public string ProductTitle => TxtProductTitle.Text;

        public string ProductPrice => TxtProductPrice.Text;

        public string ProducitType => TxtProductType.Text;

        public bool HasBadge => LnkProductBadge.Displayed;

        public AddToBasketPage ClickAddToBasket()
        {
            BtnAddToBasket.Click();

            return new AddToBasketPage(Driver);
        }
    }
}
