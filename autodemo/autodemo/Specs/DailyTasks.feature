Feature: DailyTasks
	In order to avoid getting reminder email from manager 
	As a dev
	I want to automate daily stuff

@mytag
Scenario: SubmitTimesheet
	Given I open browser with url 'https://rms.dstbluedoor.com/'
	But login with my credentials
	And redirect to timehseet for this week
	When I enter RMS code
	Then I should save
