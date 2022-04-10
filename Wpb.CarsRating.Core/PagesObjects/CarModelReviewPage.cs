using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;
using Wpb.CarsRating.Core.ContextObjects;
using Wpb.CarsRating.Core.WebDriver;

namespace Wpb.CarsRating.Core.PagesObjects
{
    public class CarModelReviewPage : BasePage
    {
        public CarModelReviewPage(IWebDriver webDriver) : base(webDriver)
        {
        }


        public override bool VerifyPage()
        {
            WebDriver.WaitUntilElementLoads(VotesCountLocator, TimeOut);
            WebDriver.WaitUntilElementLoads(CommentListContainer, TimeOut);
            return true;
        }


        public void AddComment(string comment)
        {
            WebDriver.WaitUntilElementLoads(CommentsLocator, TimeOut);
            Comments.SendKeys(comment);
        }


        public void Vote()
        {
            VoteButton.Click();
        }


        public UserReview GetComment(int commentIndex)
        {
            if (commentIndex <= 0)
                throw new InvalidOperationException($"Invalid index {commentIndex}. Index must be greater than 0.");
            var commentLocator = By.CssSelector($"tbody tr:nth-child({commentIndex}) td");
            WebDriver.WaitUntilElementLoads(commentLocator, TimeOut);
            if (!CommentsList.FindElements(commentLocator).Any())
                throw new InvalidOperationException($"No data row found for the given index number : {commentIndex}.");
            var rowElements = CommentsList.FindElements(commentLocator);
            return new UserReview
            {
                DateTime = rowElements[0].Text.Trim(),
                Author = rowElements[1].Text.Trim(),
                Review = rowElements[2].Text.Trim()
            };
        }

        public void WaitUntilLoginCommentFieldDisappears()
        {
            var webDriverWait = new WebDriverWait(WebDriver, TimeOut);
            var condition = (Func<IWebDriver, bool>)(d => !d.FindElements(CommentsLocator).Any());
            webDriverWait.Until<bool>(condition);
        }

        public string GetVoteConfirmationMessage()
        {
            WebDriver.WaitUntilElementLoads(VoteConfirmationLocator,TimeOut);
            return VoteConfirmation.Text.Trim();
        }

        public IEquatable<UserReview> GetComments()
        {
            throw new NotImplementedException();
        }

        public bool IsReviewFieldDisplayed()
        {
            return MainContainer.FindElements(CommentsLocator).Any();
        }

        public int GetVoteCount()
        {
            return Convert.ToInt32(VotesCount.Text.Trim());
        }

        public bool IsVoteButtonVisible()
        {
            return MainContainer.FindElements(VoteButtonLocator).Any();
        }

        private By VotesCountLocator => By.CssSelector("h4 strong");

        private IWebElement VotesCount => MainContainer.FindElement(VotesCountLocator);

        private By CommentsLocator => By.CssSelector(".form-control");

        private IWebElement Comments => MainContainer.FindElement(CommentsLocator);

        private By VoteButtonLocator => By.CssSelector(".btn-success");

        private IWebElement VoteButton => MainContainer.FindElement(VoteButtonLocator);

        private By CommentListContainer => By.CssSelector("table");

        private IWebElement CommentsList => MainContainer.FindElement(CommentListContainer);

        private By VoteConfirmationLocator=> By.CssSelector("p.card-text");

        private IWebElement VoteConfirmation => MainContainer.FindElement(VoteConfirmationLocator);
    }
}
