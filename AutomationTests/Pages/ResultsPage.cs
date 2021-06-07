using Framework.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System.Collections.Generic;
using System.Linq;

namespace AutomationTests.Pages
{
    public class ResultsPage : MainPage
    {
        public ResultsPage(RemoteWebDriver driver)
            : base(driver)
        {
        }

        //Section Elements
        private IWebElement LnkSubNavigationMenu => Driver.FindElementByClassName("nav-a-content");
        private IWebElement TxtDepartment => Driver.FindElementByClassName("a-size-base a-color-base a-text-bold");

        //Items Elements
        private IEnumerable<IWebElement> LnkItemTitles => Driver.FindElementsByXPath("//span[@class ='a-size-medium a-color-base a-text-normal']");
        private IEnumerable<IWebElement> ResultItems => Driver.FindElementsByXPath("//span[starts-with(@cel_widget_id, 'MAIN-SEARCH_RESULTS')]");
        private IEnumerable<IWebElement> FirstProductPrices => Driver.FindElementsByXPath("//span[@cel_widget_id = 'MAIN-SEARCH_RESULTS-1']//span[@class = 'a-price']//span[@class = 'a-offscreen']");
        private IWebElement FirstProductPrintOfType => Driver.FindElementByXPath("//span[@cel_widget_id = 'MAIN-SEARCH_RESULTS-0']//div[@class = 'a-section a-spacing-none a-spacing-top-small']//a[@class = 'a-size-base a-link-normal a-text-bold']");

        public string SubNavigationMenuValue => LnkSubNavigationMenu.Text;

        public string DepartmentValue => TxtDepartment.Text;

        public string TypeOfPrint => FirstProductPrintOfType.Text;

        public string GetPriceValue(int itemNumber)
        {
            return FirstProductPrices.GetElementFromCollection(itemNumber).GetAttribute("textContent");
        }

        public string ItemTitleValue(int itemNumber)
        {
            return LnkItemTitles.GetElementFromCollection(itemNumber).Text;
        }

        /// <summary>
        /// Checks element from results whether has a badge
        /// </summary>
        /// <param name="itemIndex"></param>
        /// <returns></returns>
        public bool HasItemBadge(int itemIndex)
        {
            if (itemIndex > 0 & itemIndex <= ResultItems.Count())
            {
                var elementBadge = Driver.FindElementByXPath($"//span[@cel_widget_id = 'MAIN-SEARCH_RESULTS-{itemIndex}']//div[@class = 'a-row a-badge-region']");

                return elementBadge.Displayed;
            }
            else
            {
                return false;
            }
        }

        public ItemPage OpenItemDetail(int itemNumber)
        {
            LnkItemTitles.GetElementFromCollection(itemNumber).Click();

            return new ItemPage(Driver);
        }
    }
}
