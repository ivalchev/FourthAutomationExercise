Feature: Open and edit Basket
	In order to acces basket
	As an active user
	I want to open successfully the basket and edit it

Background: 
Given I successfully open Main Page

@Sanity Test
Scenario: Add product in the basket
	Given I opened first item after search 
	When click on button Add to Basket
	Then notification is displayed
	And notification title should be Added to Basket
	And the items in the basket should be one

Scenario: Edit after the product is added to basket
	Given I successfully added item to basket
	When I click button Edit basket
	Then the book is displayed in basket
	And the title shoud be the same like the title from search page
	And the type of print shoud be the same like the type of print from search page
	And the price shoud be the same like the price from search page
	And quantity should be 1
	And total price should be the same like product price