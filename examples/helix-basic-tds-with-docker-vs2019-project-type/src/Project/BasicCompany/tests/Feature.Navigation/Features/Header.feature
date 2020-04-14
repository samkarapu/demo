Feature: Header
	As a website visitor
	I want to use the navigation and navigate between the pages
	


Scenario: Navigate to Homepage
	Given I am a website visitor 
	When I select 'Home' in the primary navigation  
	Then I expect to be directed to the 'Home' page  

Scenario: Navigate to Products
	Given I am a website visitor 
	When I select 'Products' in the primary navigation  
	Then I expect to be directed to the 'Products' page  


Scenario: Navigate to Services
	Given I am a website visitor 
	When I select 'Services' in the primary navigation  
	Then I expect to be directed to the 'Services' page  
