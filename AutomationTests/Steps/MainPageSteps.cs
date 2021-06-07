using AutomationTests.Hooks;
using AutomationTests.Pages;
using AutomationTests.Pages.Basket;
using FluentAssertions;
using TechTalk.SpecFlow;

namespace AutomationTests.Steps
{
    [Binding]
    public class MainPageSteps
    {
        private readonly MainPage mainPage = new MainPage(DriverHooks.Driver);
        private readonly ResultsPage resultsPage = new ResultsPage(DriverHooks.Driver);
        private readonly ItemPage itemPage = new ItemPage(DriverHooks.Driver);
        private readonly ScenarioContext scenarioContext;

        public MainPageSteps(ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;
        }

        [Given(@"I successfully open Main Page")]
        public void GivenISuccessfullyOpenMainPage()
        {
            WhenINavigateToTheMainPage();
            ThenTheMainPageIsSuccessfullyOpenedAndLoaded();
        }

        [Given(@"I successfully search item with '(.*)' from section '(.*)'")]
        public void GivenISuccessfullySearchItemWithFromSection(string text, string section)
        {
            GivenIChooseFromTheSectionsDropDown(section);
            mainPage.SearchItem(text);
        }

        [Given(@"I choose '(.*)' from the Sections drop down")]
        public void GivenIChooseFromTheSectionsDropDown(string section)
        {
            mainPage.ChooseSection(section);
        }

        [Given(@"I successfully added item to basket")]
        public void GivenISuccessfullyAddedItemToBasket()
        {
            GivenIOpenedFirstItemAfterSearch();

            itemPage.ClickAddToBasket();
        }

        [Given(@"I insert '(.*)' in search text box")]
        public void GivenIInsertInSearchTextBox(string text)
        {
            mainPage.AddTextInSearchField(text);
        }

        [Given(@"I opened first item after search")]
        public void GivenIOpenedFirstItemAfterSearch()
        {
            GivenISuccessfullySearchItemWithFromSection("Harry Potter and the Cursed Child - Parts One & Two", "Books");

            scenarioContext["Title"] =  resultsPage.ItemTitleValue(0);
            scenarioContext["TypeOfPrint"] = resultsPage.TypeOfPrint;
            scenarioContext["ProductPrice"] = resultsPage.GetPriceValue(0);

            resultsPage.OpenItemDetail(0);
        }

        [When(@"I navigate to the Main page")]
        public void WhenINavigateToTheMainPage()
        {
            mainPage.OpenMainPage();
        }

        [When(@"I click on search button")]
        public void WhenIClickOnSearchButton()
        {
            mainPage.ClickSearchButton();
        }

        [Then(@"the item with (.*) has title '(.*)'")]
        public void ThenTheItemWithHasTitle(int itemIndex, string title)
        {
            resultsPage.ItemTitleValue(itemIndex).Should().StartWith(title);
        }

        [Then(@"The Main page is successfully opened and loaded")]
        public void ThenTheMainPageIsSuccessfullyOpenedAndLoaded()
        {
            mainPage.PageTitle.Should().NotBeNull().And.Be("Amazon.co.uk: Low Prices in Electronics, Books, Sports Equipment & more");
        }

        [Then(@"the product with (.*) has badge")]
        public void ThenTheProductWithHasBadge(int itemIndex)
        {
            resultsPage.HasItemBadge(itemIndex);
        }

        [Then(@"the product with (.*) has price (.*)")]
        public void ThenTheProductWithHasPrice(int itemIndex, string price)
        {
            resultsPage.GetPriceValue(itemIndex).Should().Be(price);
        }
    }
}
