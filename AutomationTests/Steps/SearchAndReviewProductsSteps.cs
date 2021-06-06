using AutomationTests.Hooks;
using AutomationTests.Pages;
using FluentAssertions;
using System;
using TechTalk.SpecFlow;

namespace AutomationTests.Steps
{
    [Binding]
    public class SearchAndReviewProductsSteps
    {
        private string currentSection = null;
        private MainPage mainPage = new MainPage(DriverHooks.Driver);
        private ResultsPage resultsPage = new ResultsPage(DriverHooks.Driver);

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

            currentSection = section;
        }

        [Given(@"I insert '(.*)' in search text box")]
        public void GivenIInsertInSearchTextBox(string text)
        {
            mainPage.AddTextInSearchField(text);
        }

        [When(@"I click on search button")]
        public void WhenIClickOnSearchButton()
        {
            resultsPage.ClickSearchButton();
        }

        [Then(@"The (.*) has badge")]
        public void ThenTheHasBadge(int itemIndex)
        {
            resultsPage.HasItemBadge(itemIndex);
        }

        [Then(@"the item with (.*) has title '(.*)'")]
        public void ThenTheItemWithHasTitle(int itemIndex, string title)
        {
            resultsPage.ItemTitleValue(itemIndex).Should().StartWith(title);
        }

        [Then(@"The (.*) has price (.*)")]
        public void ThenTheHasPrice(int itemIndex, string price)
        {
            resultsPage.GetPriceValue(itemIndex).Should().Be(price);
        }
    }
}
