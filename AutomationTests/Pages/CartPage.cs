using Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System.Collections.Generic;
using System.Linq;

namespace AutomationTests.Pages
{
    public class CartPage : BasePage
    {
        public CartPage(RemoteWebDriver driver)
            : base(driver)
        {
        }

        private IWebElement TxtProductTitle => Driver.FindElementByClassName("a-size-medium sc-product-title");
        private IWebElement TxtProductType => Driver.FindElementByClassName("a-size-small sc-product-binding a-text-bold");
        private IWebElement TxtProductPrice => Driver.FindElementByClassName("a-size-medium a-color-base sc-price sc-white-space-nowrap sc-product-price a-text-bold");
        private IWebElement DropDownBasketQuantiy => Driver.FindElementByClassName("a-dropdown-prompt");

        //The collection contains both total price on the basket page
        private IEnumerable<IWebElement> BasketTotalPrices => Driver.FindElementsByClassName("a-size-medium a-color-base sc-price sc-white-space-nowrap");

        public string ProductTitel => TxtProductTitle.Text;
        public string ProductType => TxtProductType.Text;
        public string ProductPrice => TxtProductPrice.Text;
        public string SelectedQuantityText => DropDownBasketQuantiy.Text;

        public bool CheckBothTotalPricesAreEqual()
        {
            bool areEqual = true;
            var pricesText = new List<string>();
            var totalPrices = BasketTotalPrices.ToList();

            for (int i = 0; i < BasketTotalPrices.Count(); i++)
            {
                pricesText.Add(totalPrices[i].Text);
            }

            if (pricesText.Count > 1)
            {
                for (int i = 0; i < pricesText.Count; i++)
                {
                    if (pricesText[i] == pricesText[i + 1])
                    {
                       areEqual = true;
                    }
                    else
                    {
                       areEqual = false;
                    }
                }
            }
            else areEqual = true;

            return areEqual;
        }
    }
}
