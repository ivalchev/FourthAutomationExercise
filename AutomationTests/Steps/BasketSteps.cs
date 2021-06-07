using AutomationTests.Hooks;
using AutomationTests.Pages;
using AutomationTests.Pages.Basket;
using FluentAssertions;
using System;
using TechTalk.SpecFlow;

namespace AutomationTests.Steps
{
    [Binding]
    public class OpenAndEditBasketSteps
    {
        private readonly ItemPage itemPage = new ItemPage(DriverHooks.Driver);
        private readonly AddToBasketPage addToBasket = new AddToBasketPage(DriverHooks.Driver);
        private readonly BasketPage basketPage = new BasketPage(DriverHooks.Driver);
        private readonly MainPageSteps mainPageSteps = new MainPageSteps();
        private readonly ResultsPage resultsPage = new ResultsPage(DriverHooks.Driver);
        private string title;
        private string _typeOfPrint;
        private string _productPrice;

        [Given(@"I successfully added item to basket")]
        public void GivenISuccessfullyAddedItemToBasket()
        {
            mainPageSteps.GivenIOpenedFirstItemAfterSearch();
            WhenClickOnButtonAddToBasket();
        }

        [When(@"click on button Add to Basket")]
        public void WhenClickOnButtonAddToBasket()
        {
            itemPage.ClickAddToBasket();
        }

        [When(@"I click button Edit basket")]
        public void WhenIClickButtonEditBasket()
        {
            addToBasket.EditBasket();
        }


        [Then(@"notification is displayed")]
        public void ThenNotificationIsDisplayed()
        {
            addToBasket.CheckNotificationIsDisplayed.Should().BeTrue();
        }

        [Then(@"notification title should be Added to Basket")]
        public void ThenNotificationTitleShouldBeAddedToBasket()
        {
            addToBasket.NotificationTitle.Should().Be("Added to Basket");
        }
        
        [Then(@"the items in the basket should be one")]
        public void ThenTheItemsInTheBasketShouldBeOne()
        {
            addToBasket.BasketNumberItems.Should().Be("1");
        }
        
        [Then(@"the book is displayed in basket")]
        public void ThenTheBookIsDisplayedInBasket()
        {
            basketPage.IsDisplayedProductImage.Should().BeTrue();
        }
        
        [Then(@"the title shoud be the same like the title from search page")]
        public void ThenTheTitleShoudBeTheSameLikeTheTitleFromSearchPage()
        {
            mainPageSteps.SearchItemFromSection();

            title = resultsPage.ItemTitleValue(0);

            basketPage.ProductTitle.Should().Be(title);
        }
        
        [Then(@"the type of print shoud be the same like the type of print from search page")]
        public void ThenTheTypeOfPrintShoudBeTheSameLikeTheTypeOfPrintFromSearchPage()
        {
            mainPageSteps.SearchItemFromSection();

            string typeOfPrint = resultsPage.TypeOfPrint;

            basketPage.ProductType.Should().Be(typeOfPrint);
        }
        
        [Then(@"the price shoud be the same like the price from search page")]
        public void ThenThePriceShoudBeTheSameLikeThePriceFromSearchPage()
        {
            mainPageSteps.SearchItemFromSection();

            string productPrice = resultsPage.GetPriceValue(0);

            basketPage.ProductPrice.Should().Be(productPrice);
        }
        
        [Then(@"quantity should be (.*)")]
        public void ThenQuantityShouldBe(int number)
        {
            var quantity = number.ToString();

            basketPage.SelectedQuantityText.Should().Be(quantity);
        }
        
        [Then(@"total price should be the same like product price")]
        public void ThenTotalPriceShouldBeTheSameLikeProductPrice()
        {
            basketPage.CheckBothTotalPricesAreEqual().Should().BeTrue();

            mainPageSteps.SearchItemFromSection();
            string productPrice = resultsPage.GetPriceValue(0);

            basketPage.GetTotalPriceValue().Should().Be(productPrice);
        }
    }
}
