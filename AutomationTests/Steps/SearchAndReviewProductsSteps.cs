using System;
using TechTalk.SpecFlow;

namespace AutomationTests.Steps
{
    [Binding]
    public class SearchAndReviewProductsSteps
    {

        [Given(@"I insert '(.*)' in search text box")]
        public void GivenIInsertInSearchTextBox(string p0)
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"I choose '(.*)' from the Sections drop down")]
        public void GivenIChooseFromTheSectionsDropDown(string p0)
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"Click on search button")]
        public void WhenClickOnSearchButton()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"The first item has title ""(.*)""")]
        public void ThenTheFirstItemHasTitle(string p0)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"The item has badge")]
        public void ThenTheItemHasBadge()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"The item has price")]
        public void ThenTheItemHasPrice()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
