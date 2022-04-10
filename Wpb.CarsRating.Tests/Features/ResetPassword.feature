@Web @Login
Feature: Reset password
As a buggy cars rating portal member
I want to regularly change my login credentials
So that I can keep my user account safe

	
	@BCR-0008
	Scenario: Registered user resets the password
		Given I am a registered buggy cars rating portal user
		And I have opened the buggy cars rating portal
		And I have logged into the buggy cars rating portal
		And I have navigated to user profile page
		And I have filled in my current password
		And I have filled in my new password
		When I save my changes
		Then I see a success message 'The profile has been saved successful' 


	@BCR-0009
	Scenario: Registered user who has reset the password logs in using new credentials
		Given I am a registered buggy cars rating portal user
		And I have opened the buggy cars rating portal
		And I have logged into the buggy cars rating portal
		And I have navigated to user profile page
		And I have successfully reset my password
		And I have logged out
		And I have entered my new credentials
		When I log in
		And I see a personal greeting message
