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
        private string currentSection;
        private MainPage mainPage;
        private ResultsPage resultsPage;

        [Given(@"I choose '(.*)' from the Sections drop down")]
        public void GivenIChooseFromTheSectionsDropDown(string section)
        {
            mainPage = new MainPage(DriverHooks.Driver);
            mainPage.ChooseSection(section);

            currentSection = section;
        }

        [Given(@"I insert '(.*)' in search text box")]
        public void GivenIInsertInSearchTextBox(string text)
        {
            mainPage.AddTextInSearchField(text);
        }


        [When(@"Click on search button")]
        public void WhenClickOnSearchButton()
        {
            resultsPage = new ResultsPage(DriverHooks.Driver);
            resultsPage.ClickSearchButton();
        }

        [Then(@"The first item has title ""(.*)""")]
        public void ThenTheFirstItemHasTitle(string title)
        {
        }

        [Then(@"The (.*) has badge")]
        public void ThenTheHasBadge(int itemIndex)
        {
            resultsPage.HasItemBadge(itemIndex);
        }

        [Then(@"The (.*) has price")]
        public void ThenTheHasPrice(int itemIndex)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"The item with (.*) has title '(.*)'")]
        public void ThenTheItemHasTitle(int itemIndex, string title)
        {
            resultsPage.ItemTitleValue(itemIndex).Should().StartWith(title);
        }
    }
}
