Feature: Login
	In order to access Adviser Portal
	As a Adviser
	I want to login to the portal

Background: 
Given I am an aviser
When I enter my credentials


@pc
Scenario: Login to the portal
	Then I should successfully login to the portal

Scenario: Redirect to user profile page	
	Then I should redirect to User profile page
	
