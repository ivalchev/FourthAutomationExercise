using Framework;
using Framework.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System.Collections.Generic;
using System.Linq;

namespace AutomationTests.Pages.Basket
{
    public class BasketPage : BasePage
    {
        public BasketPage(RemoteWebDriver driver)
            : base(driver)
        {
        }

        private IWebElement TxtProductTitle => Driver.FindElementByXPath("//span[@class = 'a-size-medium a-color-base sc-product-title']");
        private IWebElement TxtProductType => Driver.FindElementByCssSelector("span[class = 'a-size-small sc-product-binding a-text-bold']");
        private IWebElement TxtProductPrice => Driver.FindElementByCssSelector("span[class = 'a-size-medium a-color-base sc-price sc-white-space-nowrap sc-product-price a-text-bold']");
        private IWebElement DropDownBasketQuantiy => Driver.FindElementByClassName("a-dropdown-prompt");
        private IWebElement ImgProductImage => Driver.FindElementByClassName("sc-product-image");

        //The collection contains both total price on the basket page
        private IEnumerable<IWebElement> BasketTotalPrices => Driver.FindElementsByCssSelector("span[class = 'a-size-medium a-color-base sc-price sc-white-space-nowrap']");

        public string ProductTitle => TxtProductTitle.Text;
        public string ProductType => TxtProductType.Text;
        public string ProductPrice => TxtProductPrice.Text;
        public string SelectedQuantityText => DropDownBasketQuantiy.Text;
        public bool IsDisplayedProductImage => ImgProductImage.Displayed;

        /// <summary>
        /// Check whether the both total prices on the screen are equal
        /// </summary>
        /// <returns></returns>
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
                for (int i = 0; i < pricesText.Count-1; i++)
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

        //Use only when first checks the both total price are equal
        public string GetTotalPriceValue()
        {
            return BasketTotalPrices.GetElementFromCollection(0).Text;
        }
    }
}
