@Web @Rating
Feature: Rating car models
As a buggy cars rating portal member
I want to vote for & review my favorite car models
So that portal members get to know how popular the car models are


	@BCR-0010
	Scenario: Registered user votes for a favorite car model
		Given I am a registered buggy cars rating portal user
		And I have opened the buggy cars rating portal
		And I have logged into the buggy cars rating portal
		And I have navigated to my favorite car model's page
		And I have reviewed the model
		When I vote 
		Then my vote is reflected in the vote count
		And I see the message 'Thank you for your vote!'
		And I cannot add any more review comments
		And I my review is added to the top of the review list


	@BCR-0011
	Scenario: Unregistered user is unable to votes for a favorite car model
		Given I am a registered buggy cars rating portal user
		And I have opened the buggy cars rating portal
		When I navigate to my favorite car model's page
		Then I cannot vote 
		And I cannot add any reviews
		And I can see the number of votes
		And I see the message 'You need to be logged in to vote.'
