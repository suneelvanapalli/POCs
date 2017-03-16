Feature: Login
	In order to access Adviser Portal
	As a Adviser
	I want to login to the portal

@pc
Scenario: Login to the portal
	Given I am an aviser
	When I enter my credentials
	Then I should successfully login to the portal
