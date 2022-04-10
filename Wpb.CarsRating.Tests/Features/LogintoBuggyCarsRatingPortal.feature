@Web @Login
Feature: Login to buggy cars rating portal
As a buggy cars rating portal member
I want to login to buggy cars rating portal
So that I can access my user profile


	@BCR-0006
	Scenario: Registered user login to buggy cars rating portal
		Given I am a registered buggy cars rating portal user
		And I have opened the buggy cars rating portal
		And I have entered my credentials
		When I log in
		Then the user login form is hidden
		And the Register button is hidden
		And I see a personal greeting message
		And I can navigate to my profile page
		And I can log out


	@BCR-0007
	Scenario: A user attempts to log in using invalid credentials
		Given I have opened the buggy cars rating portal
		And I have not signed into buggy cars rating portal
		And I have entered incorrect credentials
		When I attempt to log in
		Then I see an login error message 'Invalid username/password'