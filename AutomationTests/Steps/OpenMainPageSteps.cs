using AutomationTests.Hooks;
using AutomationTests.Pages;
using FluentAssertions;
using TechTalk.SpecFlow;

namespace AutomationTests.Steps
{
    [Binding]
    public class OpenMainPageSteps
    {
        private MainPage mainPage;

        [When(@"I navigate to the Main page")]
        public void WhenINavigateToTheMainPage()
        {
            mainPage = new MainPage(DriverHooks.Driver);
            mainPage.OpenMainPage();
        }
        
        [Then(@"The Main page is successfully opened")]
        public void ThenTheMainPageIsSuccessfullyOpened()
        {
            mainPage.PageTitle.Should().NotBeNull().And.Be("Amazon.co.uk: Low Prices in Electronics, Books, Sports Equipment & more");
        }
    }
}
