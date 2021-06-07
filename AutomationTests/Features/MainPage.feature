Feature: Open and Search on MainPage
	In order to access main page
	As an active user
	I want to open successfully the webpage and search products

Background: 
	Given I successfully open Main Page

@Sanity Test
Scenario Outline: Search item from specific section
	Given I choose '<section>' from the Sections drop down 
	And I insert '<search criterias>' in search text box
	When I click on search button
	Then the item with <index> has title '<title>'
	And the product with <index> has badge
	And the product with <index> has price <price>
Examples: 
	| section | search criterias                  | title                                                 | index | price |
	| Books   | Harry Potter and the Cursed Child | Harry Potter and the Cursed Child - Parts One & Two   | 0     | £4.00 |
	| Books   | Harry Potter and the Cursed Child | Harry Potter and the Cursed Child - Parts One and Two | 0     | £4.00 |
