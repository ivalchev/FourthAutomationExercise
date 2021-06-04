Feature: Search and review products 
	In order to acces main page
	As an active unregistered user
	I want to search and review products

Background: I navigate to Main Page
Given I successfully open Main Page

@mytag
Scenario Outline: Search first item in specific section
	Given I choose '<section>' from the Sections drop down 
	And I insert '<search criterias>' in search text box
	When Click on search button
	Then The first item has title '<title>'
	And The item has badge
	And The item has price
Examples: 
	| section  | search criterias                      | title                                                 |
	| Books    | "Harry Potter and the Cursed Child"   | "Harry Potter and the Cursed Child - Parts One & Two" |