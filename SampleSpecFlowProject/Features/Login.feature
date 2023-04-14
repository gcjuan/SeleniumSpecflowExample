Feature: Sample Login Test

Scenario: User is able to login with correct credentials
	Given I go to the site 'https://practicetestautomation.com/practice-test-login/'
	And I the username 'student' with password 'Password123'
	When I click the submit button
	Then I should login successfully 

Scenario: User is unable to login with incorrect credentials
	Given I go to the site 'https://practicetestautomation.com/practice-test-login/'
	And I the username 'invalid' with password 'test'
	When I click the submit button
	Then the error 'Your username is invalid!' is displayed