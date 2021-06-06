Feature: Search and review products 
	In order to acces main page
	As an active unregistered user
	I want to search and review products

Background: I navigate to Main Page
Given I successfully open Main Page

@mytag
Scenario Outline: Search item in specific section
	Given I choose '<section>' from the Sections drop down 
	And I insert '<search criterias>' in search text box
	When I click on search button
	Then the item with <index> has title '<title>'
	And The <index> has badge
	And The <index> has price <price>
Examples: 
	| section | search criterias                  | title                                                 | index | price |
	| Books   | Harry Potter and the Cursed Child | Harry Potter and the Cursed Child - Parts One & Two   | 0     | £4.00 |
	| Books   | Harry Potter and the Cursed Child | Harry Potter and the Cursed Child - Parts One and Two | 0     | £4.00 |