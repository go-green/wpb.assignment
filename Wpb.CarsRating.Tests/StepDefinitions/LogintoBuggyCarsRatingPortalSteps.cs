using FluentAssertions;
using OpenQA.Selenium;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using Wpb.CarsRating.Core.ApiServices.Contracts;
using Wpb.CarsRating.Core.ContextObjects;
using Wpb.CarsRating.Core.Utils;
using Wpb.CarsRating.Core.PagesObjects;

namespace Wpb.CarsRating.Tests.StepDefinitions
{
    [Binding]
    public class LogintoBuggyCarsRatingPortalSteps : BaseSteps
    {
        private readonly IUser _userApiClient;
        private readonly Navigator _navigator;
        public LogintoBuggyCarsRatingPortalSteps(
            IWebDriver webDriver,
            ContextInitializer context,
            IUser userApiClient, 
            Navigator navigator) : base(webDriver, context)
        {
            _userApiClient = userApiClient;
            _navigator = navigator;
        }


        [Given(@"I am a registered buggy cars rating portal user")]
        public async Task GivenIAmARegisteredBuggyCarsRatingPortalUser()
        {
            var user = Context.Get<UserUnderTest>().Current = TestData.GetRandomUser();
            (await _userApiClient.RegisterUser(user)).Should().BeTrue();
        }


        [Given(@"I have not signed into buggy cars rating portal")]
        public void GivenIHaveNotSignedIntoBuggyCarsRatingPortal()
        {
            Context.Get<UserUnderTest>().Current = TestData.GetRandomUser();
        }


        [Given(@"I have entered my credentials")]
        public void GivenIHaveEnteredMyCredentials()
        {
            var user = Context.Get<UserUnderTest>().Current;
            _navigator.LoginForm.EnterCredential(user.LoginName, user.Password);
        }


        [When(@"I log in")]
        public void WhenILogIn()
        {
            _navigator.LoginForm.Login();
            _navigator.WaitUntilLoginFormDisappears();
        }


        [Then(@"the user login form is hidden")]
        public void ThenTheUserLoginFormIsHidden()
        {
            _navigator.LoginFormDisplayed().Should().BeFalse();
        }


        [Then(@"the Register button is hidden")]
        public void ThenTheRegisterButtonIsHidden()
        {
            _navigator.RegisterButtonDisplayed().Should().BeFalse();
        }


        [Then(@"I can navigate to my profile page")]
        public void ThenICanNavigateToMyProfilePage()
        {
            _navigator.ProfileLinkDisplayed().Should().BeTrue();
        }


        [Then(@"I can log out")]
        public void ThenICanLogOut()
        {
            _navigator.LogoutButtonDisplayed().Should().BeTrue();
        }


        [When(@"I see a personal greeting message")]
        [Then(@"I see a personal greeting message")]
        public void ThenISeeAPersonalGreetingMessage()
        {
            var user = Context.Get<UserUnderTest>().Current;
            _navigator.GetGreetingMessage().Should().Be($"Hi, {user.FirstName}");
        }


        [Given(@"I have entered incorrect credentials")]
        public void GivenIHaveEnteredIncorrectCredentials()
        {
            var user = Context.Get<UserUnderTest>().Current;
            _navigator.LoginForm.EnterCredential(user.LoginName, user.Password);
        }

        [When(@"I attempt to log in")]
        public void WhenIAttemptToLogin()
        {
            _navigator.LoginForm.Login();
        }

        [Then(@"I see an login error message '([^']*)'")]
        public void ThenISeeAnLoginErrorMessage(string error)
        {
            _navigator.LoginForm.GetLoginError().Should().Be(error);
        }
    }
}
