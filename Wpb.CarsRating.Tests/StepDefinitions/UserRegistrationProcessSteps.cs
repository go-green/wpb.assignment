using FluentAssertions;
using OpenQA.Selenium;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using Wpb.CarsRating.Core.ApiServices.Contracts;
using Wpb.CarsRating.Core.Configurations;
using Wpb.CarsRating.Core.ContextObjects;
using Wpb.CarsRating.Core.PagesObjects;
using Wpb.CarsRating.Core.Utils;

namespace Wpb.CarsRating.Tests.StepDefinitions
{
    [Binding]
    public class UserRegistrationProcessSteps : BaseSteps
    {
        private readonly Navigator _navigator;
        private readonly RegistrationPage _registrationPage;
        private readonly IUser _userApiClient;
        private readonly HomePage _homePage;

        public UserRegistrationProcessSteps(
            IWebDriver webDriver,
            ContextInitializer context,
            Navigator navigator,
            RegistrationPage registrationPage,
            IUser userApiClient, 
            HomePage homePage)
            : base(webDriver, context)
        {
            _navigator = navigator;
            _registrationPage = registrationPage;
            _userApiClient = userApiClient;
            _homePage = homePage;
        }


        [Given(@"I have opened the buggy cars rating portal")]
        public void GivenIHaveOpenTheBuggyCarsRatingPortal()
        {
            WebDriver.Navigate().GoToUrl(AppSettings.Web.Url);
        }


        [Given(@"I have navigated to user registration page")]
        public void GivenIHaveNavigatedToUserRegistrationPage()
        {
            _navigator.NavigateTo("Register");
            _registrationPage.VerifyPage().Should().BeTrue();
        }


        [When(@"I fill in all the mandatory fields")]
        [Given(@"I have filled in all the mandatory fields")]
        public void GivenIHaveFilledInAllTheMandatoryFields()
        {
            var user = Context.Get<UserUnderTest>().Current = TestData.GetRandomUser();
            _registrationPage.EnterUserDetails(user);
        }


        [When(@"I attempt to register")]
        [When(@"I click on the register button")]
        public void WhenIClickOnTheRegisterButton()
        {
            _registrationPage.Register();
        }


        [Then(@"I see success message '([^']*)'")]
        public void ThenISeeSuccessMessage(string message)
        {
            _registrationPage.GetSuccessMessage().Should().Be(message);
        }


        [Then(@"all the fields are cleared of any content")]
        public void ThenAllTheFieldsAreClearedOfAnyContent()
        {
            var formFields = _registrationPage.GetRegistrationFormFieldValues();
            formFields.LoginName.Should().Be(string.Empty);
            formFields.FirstName.Should().Be(string.Empty);
            formFields.LastName.Should().Be(string.Empty);
            formFields.Password.Should().Be(string.Empty);
            formFields.ConfirmPassword.Should().Be(string.Empty);
        }


        [Then(@"the Register button is enabled")]
        public void ThenTheRegisterButtonIsEnabled()
        {
            _registrationPage.IsRegisterButtonEnabled.Should().BeTrue();
        }


        [Given(@"I have filled in my user details using a login name that already exists")]
        public async Task GivenIHaveFilledInMyUserDetailsUsingALoginNameThatAlreadyExists()
        {
            var user = Context.Get<UserUnderTest>().Current = TestData.GetRandomUser();
            (await _userApiClient.RegisterUser(user)).Should().BeTrue();
            _registrationPage.EnterUserDetails(user);
        }


        [Then(@"I see an error message '([^']*)'")]
        public void ThenISeeAnErrorMessage(string error)
        {
            _registrationPage.GetErrorMessage().Should().Be(error);
        }


        [When(@"I fill in all fields except for '([^']*)'")]
        public void WhenIFillInAllFieldsExceptFor(string field)
        {
            var user = Context.Get<UserUnderTest>().Current = TestData.GetRandomUser();
            _registrationPage.EnterUserDetailsExcept(field, user);
        }


        [Then(@"I see an '([^']*)' message next to '([^']*)'")]
        public void ThenISeeAnMessageNextTo(string error, string field)
        {
            _registrationPage.GetFieldError(field).Should().Be(error);
        }


        [Then(@"the '([^']*)' in error is highlighted")]
        public void ThenTheInErrorIsHighlighted(string field)
        {
            _registrationPage.IsFieldInError(field).Should().BeTrue();
        }


        [When(@"I click on the cancel button")]
        public void WhenIClickOnTheCancelButton()
        {
            _registrationPage.Cancel();
        }

        [Then(@"I am navigated to home page")]
        public void ThenIAmNavigatedToHomePage()
        {
            _homePage.VerifyPage().Should().BeTrue();
        }
    }
}
