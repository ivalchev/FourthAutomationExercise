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
        //TODO Created test for the prices !!!!
        private IEnumerable<IWebElement> FirstPagePrices => Driver.FindElementsByXPath($"//span[@cel_widget_id = 'MAIN-SEARCH_RESULTS-1']//div[@class = 'a-row a-badge-region']");


        public string SubNavigationMenuValue => LnkSubNavigationMenu.Text;

        public string DepartmentValue => TxtDepartment.Text;

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

        public ItemPage NavigateToItem(int itemNumber)
        {
            LnkItemTitles.GetElementFromCollection(itemNumber).Click();

            return new ItemPage(Driver);
        }
    }
}
