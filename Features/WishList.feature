Feature: WishList
	

Scenario Outline: Verify that a user can create a wishlist through a car giant Portal 
	Given that the Car Giant web Application is launched
	And a user clicks the login link
	And a user enters georgeiwoiltd@aol.com in the email field
	And a user enters Testing123 in the password field
	And a user scrols down
	And a user clicks the sign in button
	And a user clicks on home link
	And a user clicks on search link
	When a user clicks FirstCar watchlist button
	And a user scrols down
	When a user clicks SecondCar watchlist button
	And a user scrols down Twice
	When a user clicks ThirdCar watchlist button
	And a user clicks on My Garage
	Then the <ExpectedWatchListScreen> should be displayed
	Examples: 
	| ExpectedWatchListScreen              |
	| https://www.cargiant.co.uk/my-garage |  


Scenario: Verify that a user can delete an item from a wishlist
	Given that the Car Giant web Application is launched
	And a user clicks the login link
	And a user enters georgeiwoiltd@aol.com in the email field
	And a user enters Testing123 in the password field
	And a user scrols down
	And a user clicks the sign in button
	And a user clicks on My Garage
	And a user scrols down fullPage
	And a user clicks on Remove From Watchlist
	And a user scrols down fullPage
	Then the number of cars remaining 2 sshould be displayed
	
	





