using Bogus.DataSets;
using FluentAssertions;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;
using Wpb.CarsRating.Core.ContextObjects;
using Wpb.CarsRating.Core.PagesObjects;

namespace Wpb.CarsRating.Tests.StepDefinitions
{
    [Binding]
    public class RatingCarModelsSteps : BaseSteps
    {
        private readonly HomePage _homePage;
        private readonly CarModelReviewPage _carModelReviewPage;

        public RatingCarModelsSteps(
            IWebDriver webDriver,
            ContextInitializer context,
            HomePage homePage, 
            CarModelReviewPage carModelReviewPage)
            : base(webDriver, context)
        {
            _homePage = homePage;
            _carModelReviewPage = carModelReviewPage;
        }


        [When(@"I navigate to my favorite car model's page")]
        [Given(@"I have navigated to my favorite car model's page")]
        public void GivenIHaveNavigatedToMyFavoriteCarModelsPage()
        {
            _homePage.VerifyPage().Should().BeTrue();   
            _homePage.GotoPopularModel();
            _carModelReviewPage.VerifyPage().Should().BeTrue();
            var review = Context.Get<ReviewUnderTest>().Current;
            review.VoteCount = _carModelReviewPage.GetVoteCount();
        }


        [Given(@"I have reviewed the model")]
        public void GivenIHaveReviewedTheModel()
        {
            var review = Context.Get<ReviewUnderTest>().Current;
            review.Review = new Lorem().Paragraph(3);
            _carModelReviewPage.AddComment(review.Review);
        }


        [When(@"I vote")]
        public void WhenIVote()
        {
            _carModelReviewPage.Vote();
            _carModelReviewPage.WaitUntilLoginCommentFieldDisappears();
            var review = Context.Get<ReviewUnderTest>().Current;
            review.DateTime = DateTime.Now.ToString("MMM dd, yyyy");
        }
        

        [Then(@"my vote is reflected in the vote count")]
        public void ThenMyVoteIsReflectedInTheVoteCount()
        {
            var review = Context.Get<ReviewUnderTest>().Current;
            _carModelReviewPage.GetVoteCount().Should().Be(review.VoteCount + 1);
        }


        [Then(@"I see the message '([^']*)'")]
        public void ThenISeeTheMessage(string voteConfirmation)
        {
            _carModelReviewPage.GetVoteConfirmationMessage().Should().Be(voteConfirmation);
        }


        [Then(@"I cannot add any more review comments")]
        public void ThenICannotAddAnyMoreReviewComments()
        {
            _carModelReviewPage.IsReviewFieldDisplayed().Should().BeFalse();
        }


        [Then(@"I my review is added to the top of the review list")]
        public void ThenIMyReviewIsAddedToTheTopOfTheReviewList()
        {
            var user = Context.Get<UserUnderTest>().Current;
            var review = Context.Get<ReviewUnderTest>().Current;

            var comment = _carModelReviewPage.GetComment(1);

            comment.Author.Should().Be(user.FullName);
            comment.DateTime.Should().Contain(review.DateTime);
            comment.Review.Should().Be(review.Review);
        }


        [Then(@"I cannot vote")]
        public void ThenICannotVote()
        {
            _carModelReviewPage.IsVoteButtonVisible().Should().BeFalse();
        }


        [Then(@"I cannot add any reviews")]
        public void ThenICannotAddAnyReviews()
        {
            _carModelReviewPage.IsReviewFieldDisplayed().Should().BeFalse();
        }


        [Then(@"I can see the number of votes")]
        public void ThenICanSeeTheNumberOfVotes()
        {
            _carModelReviewPage.GetVoteCount().Should().NotBe(null);
        }

    }
}
