using AutomationTests.Hooks;
using AutomationTests.Pages;
using FluentAssertions;
using TechTalk.SpecFlow;

namespace AutomationTests.Steps
{
    [Binding]
    public class ItemDetailsSteps
    {
        private ResultsPage resultPage = new ResultsPage(DriverHooks.Driver);
        private ItemPage itemDetails = new ItemPage(DriverHooks.Driver);

        [When(@"I click on the (.*) product title")]
        public void WhenIClickOnTheProductTitle(int number)
        {
            resultPage.OpenItemDetail(number);
        }
        
        [Then(@"product has a badge")]
        public void ThenProductHasABadge()
        {
            itemDetails.HasBadge.Should().BeTrue();
        }

        [Then(@"product title should be '(.*)'")]
        public void ThenProductTitleShouldBe(string title)
        {
            itemDetails.ProductTitle.Should().StartWith(title);
        }

        [Then(@"product price should be '(.*)'")]
        public void ThenProductPriceShouldBe(string price)
        {
            itemDetails.ProductPrice.Should().Be(price);
        }

        [Then(@"product type shoudl be '(.*)'")]
        public void ThenProductTypeShoudlBe(string type)
        {
            itemDetails.ProducitType.Should().StartWith(type);
        }
    }
}
