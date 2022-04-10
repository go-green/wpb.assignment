using FluentAssertions;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;
using Wpb.CarsRating.Core.ContextObjects;
using Wpb.CarsRating.Core.PagesObjects;
using Wpb.CarsRating.Core.Utils;

namespace Wpb.CarsRating.Tests.StepDefinitions
{
    [Binding]
    public class ResetPasswordSteps : BaseSteps
    {
        private readonly Navigator _navigator;
        private readonly ProfilePage _profilePage;
        public ResetPasswordSteps(
            IWebDriver webDriver,
            ContextInitializer context, 
            Navigator navigator, 
            ProfilePage profilePage)
            : base(webDriver, context)
        {
            _navigator = navigator;
            _profilePage = profilePage;
        }


        [Given(@"I have navigated to user profile page")]
        public void GivenIHaveNavigatedToUserProfilePage()
        {
            _navigator.NavigateTo("Profile");
            _profilePage.VerifyPage().Should().BeTrue();
        }


        [Given(@"I have filled in my current password")]
        public void GivenIHaveFilledInMyCurrentPassword()
        {
            var user = Context.Get<UserUnderTest>().Current;
            _profilePage.EnterCurrentPassword(user.Password);
        }


        [Given(@"I have logged into the buggy cars rating portal")]
        public void GivenIHaveLoggedIntoTheBuggyCarsRatingPortal()
        {
            var user = Context.Get<UserUnderTest>().Current;
            _navigator.LoginForm.Login(user.LoginName, user.Password);
            _navigator.WaitUntilLoginFormDisappears();
        }


        [Given(@"I have filled in my new password")]
        public void GivenIHaveFilledInMyNewPassword()
        {
            var user = Context.Get<UserUnderTest>().Current;
            var newPassword = TestData.ReverseText(user.Password);
            _profilePage.EnterNewPassword(newPassword);
            user.Password = newPassword;
        }


        [When(@"I save my changes")]
        public void WhenISaveMyChanges()
        {
            _profilePage.Save();
        }


        [Then(@"I see a success message '([^']*)'")]
        public void ThenISeeASuccessMessage(string message)
        {
            _profilePage.GetSuccessMessage().Should().Be(message);
        }


        [Given(@"I have successfully reset my password")]
        public void GivenIHaveSuccessfullyResetMyPassword()
        {
            var user = Context.Get<UserUnderTest>().Current;
            var newPassword = TestData.ReverseText(user.Password);
            _profilePage.ResetPassword(user.Password, newPassword);
            _profilePage.GetSuccessMessage().Should().NotBeNull();
            user.Password = newPassword;
        }


        [Given(@"I have logged out")]
        public void GivenIHaveLoggedOut()
        {
            _navigator.Logout();
            _navigator.LoginFormDisplayed().Should().BeTrue();
        }


        [Given(@"I have entered my new credentials")]
        public void GivenIHaveEnteredMyNewCredentials()
        {
            var user = Context.Get<UserUnderTest>().Current;
            _navigator.LoginForm.Login(user.LoginName, user.Password);
        }


    }
}
