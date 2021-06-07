using Framework.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System.Collections.Generic;

namespace AutomationTests.Pages.Basket
{
    public class AddToBasketPage : MainPage
    {
        public AddToBasketPage(RemoteWebDriver driver)
            :base(driver)
        {
        }

        private IWebElement AdddedToBasketNotification => Driver.FindElementById("huc-v2-order-row-inner");
        private IWebElement TxtNotificationTitle => Driver.FindElementByXPath("//h1[@class ='a-size-medium a-text-bold']");
        private IEnumerable<IWebElement> TxtBasketNumberItems => Driver.FindElementsByCssSelector("span[class = 'a-size-medium a-align-center huc-subtotal'] span");
        private IWebElement BtnEditBasket => Driver.FindElementById("hlb-view-cart-announce");

        public string NotificationTitle => TxtNotificationTitle.Text;

        //Get only quantity number from the string "Basket subtotal (1 items):"
        public string BasketNumberItems => TxtBasketNumberItems.GetElementFromCollection(0).Text.GetSubStringFromString(17,1);
         
        public bool CheckNotificationIsDisplayed => AdddedToBasketNotification.Displayed;

        public BasketPage EditBasket()
        {
            BtnEditBasket.Click();

            return new BasketPage(Driver);
        }
    }
}
