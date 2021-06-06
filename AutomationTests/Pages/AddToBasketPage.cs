using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace AutomationTests.Pages
{
    public class AddToBasketPage : MainPage
    {
        public AddToBasketPage(RemoteWebDriver driver)
            :base(driver)
        {
        }

        private IWebElement AddToBasketNotification => Driver.FindElementById("huc-v2-order-row-inner");
        private IWebElement TxtNotificationTitle => Driver.FindElementByClassName("a-size-medium a-text-bold");
        private IWebElement TxtBasketNumberItems => Driver.FindElementByClassName("a-size-medium a-align-center huc-subtotal");
        private IWebElement BtnEditBasket => Driver.FindElementById("hlb-view-cart-announce");

        public string NotificationTitle => TxtNotificationTitle.Text;

        public string BasketNumberItems => TxtBasketNumberItems.Text;

        public CartPage EditBasket()
        {
            BtnEditBasket.Click();

            return new CartPage(Driver);
        }
    }
}
