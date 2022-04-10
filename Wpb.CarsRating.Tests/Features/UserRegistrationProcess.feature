@Web @SignIn 
Feature: User registration process
As an automobile enthusiast
I want to create an account on buggy cars rating portal
So that I can have access to the services offered by the buggy cars rating portal


	@BCR-0001
	Scenario: A user registers with buggy cars rating portal
		Given I have opened the buggy cars rating portal
		And I have navigated to user registration page
		And I have filled in all the mandatory fields
		When I click on the register button
		Then I see success message 'Registration is successful'
		And all the fields are cleared of any content

	
	@BCR-0002
	Scenario: The register button is enabled after all the mandatory information is provided 
		Given I have opened the buggy cars rating portal
		And I have navigated to user registration page
		When I fill in all the mandatory fields
		Then the Register button is enabled


	@BCR-0003
	Scenario: A user attempts to register using a login name that already exists
		Given I have opened the buggy cars rating portal
		And I have navigated to user registration page
		And I have filled in my user details using a login name that already exists
		When I attempt to register
		Then I see an error message 'UsernameExistsException: User already exists'


	@BCR-0004
	Scenario Outline: A user attempts to register without providing mandatory details
		Given I have opened the buggy cars rating portal
		And I have navigated to user registration page
		When I fill in all fields except for '<field>'
		Then I see an '<error>' message next to '<field>'
		And the '<field>' in error is highlighted

		Examples: 
		| Description      | field            | error                  |
		| Login Name       | Login            | Login is required      |
		| First Name       | First Name       | First Name is required |
		| Last Name        | Last Name        | Last Name is required  |
		| Password         | Password         | Password is required   |
		| Confirm Password | Confirm Password | Passwords do not match |


	@BCR-0005
	Scenario: A user navigates back to home page from registration page
		Given I have opened the buggy cars rating portal
		And I have navigated to user registration page
		When I click on the cancel button
		Then I am navigated to home page