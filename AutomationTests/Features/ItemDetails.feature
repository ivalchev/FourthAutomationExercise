Feature: ItemDetails
	In order to acces item detail
	As an active user
	I want to open successfully the product page

Background: 
Given I successfully open Main Page

@Sanity
Scenario Outline: Open the first product details after search
	Given I successfully search item with '<text>' from section '<section>'
	When I click on the <number> product title 
	Then product title should be '<title>'
	And product has a badge
	And product price should be '<price>'
	And product type shoudl be '<type>'
Examples: 
	| text                              | section | title                                                 | price | type      | number |
	| Harry Potter and the Cursed Child | Books   | Harry Potter and the Cursed Child - Parts One & Two   | £4.00 | Paperback | 0      |
	| Harry Potter and the Cursed Child | Books   | Harry Potter and the Cursed Child - Parts One and Two | £4.00 | Paperback | 0      |

