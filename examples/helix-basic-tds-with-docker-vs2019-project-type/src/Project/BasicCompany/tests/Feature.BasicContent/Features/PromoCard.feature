

@PromoCard
Feature: PromoCard
	As a website visitor 
	I want to see promo cards


Scenario: Promo cards visible
	Given I am a website visitor 
	When I navigate to the Home page  
	Then I expect to see promo cards  
