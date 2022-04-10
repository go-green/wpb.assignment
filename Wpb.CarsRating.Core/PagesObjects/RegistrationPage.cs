using OpenQA.Selenium;
using System;
using Wpb.CarsRating.Core.ContextObjects;
using Wpb.CarsRating.Core.WebDriver;

namespace Wpb.CarsRating.Core.PagesObjects
{
    public class RegistrationPage : BasePage
    {
        public RegistrationPage(IWebDriver webDriver) : base(webDriver)
        {
        }

        public override bool VerifyPage()
        {
            WebDriver.WaitUntilElementLoads(MainContainerLocator, TimeOut);
            WebDriver.WaitUntilElementLoads(LoginLocator, TimeOut);
            WebDriver.WaitUntilElementLoads(FirstNameLocator, TimeOut);
            WebDriver.WaitUntilElementLoads(LastNameLocator, TimeOut);
            WebDriver.WaitUntilElementLoads(PasswordLocator, TimeOut);
            WebDriver.WaitUntilElementLoads(ConfirmPasswordLocator, TimeOut);
            return true;
        }

        public void EnterUserDetails(UserDetails user)
        {
            LoginName.Enter(user.LoginName);
            FirstName.Enter(user.FirstName);
            LastName.Enter(user.LastName);
            Password.EnterPassword(user.Password);
            ConfirmPassword.EnterPassword(user.Password);
        }

        public void EnterUserDetailsExcept(string field, UserDetails user)
        {
            EnterUserDetails(user);
            switch (field)
            {
                case "Login":
                    LoginName.ClearTextField();
                    break;
                case "First Name":
                    FirstName.ClearTextField();
                    break;
                case "Last Name":
                    LastName.ClearTextField();
                    break;
                case "Password":
                    Password.ClearPasswordField();
                    break;
                case "Confirm Password":
                    ConfirmPassword.ClearPasswordField();
                    break;
                default:
                    throw new ArgumentOutOfRangeException($"Unsupported field: {field}");

            }
        }


        public string GetFieldError(string field)
        {
            switch (field)
            {
                case "Login":
                    return LoginName.GetFieldError();
                case "First Name":
                    return FirstName.GetFieldError();
                case "Last Name":
                    return LastName.GetFieldError();
                case "Password":
                    return Password.GetFieldError();
                case "Confirm Password":
                    return ConfirmPassword.GetFieldError();
                default:
                    throw new ArgumentOutOfRangeException($"Unsupported field: {field}");

            }
        }


        public bool IsFieldInError(string field)
        {
            switch (field)
            {
                case "Login":
                    return LoginName.IsFieldInError;
                case "First Name":
                    return FirstName.IsFieldInError;
                case "Last Name":
                    return LastName.IsFieldInError;
                case "Password":
                    return Password.IsFieldInError;
                case "Confirm Password":
                    return ConfirmPassword.IsFieldInError;
                default:
                    throw new ArgumentOutOfRangeException($"Unsupported field: {field}");

            }
        }

        public string GetSuccessMessage()
        {
            WebDriver.WaitUntilElementLoads(SucessMessageLocator, TimeOut);
            return SucessMessage.Text.Trim();
        }

        public string GetErrorMessage()
        {
            WebDriver.WaitUntilElementLoads(ErrorMessageLocator, TimeOut);
            return ErrorMessage.Text.Trim();
        }


        public UserDetails GetRegistrationFormFieldValues()
        {
            return new UserDetails
            {
                LoginName = LoginName.GetTextFieldValue(),
                FirstName = FirstName.GetTextFieldValue(),
                LastName = LastName.GetTextFieldValue(),
                Password = Password.GetPasswordFieldValue(),
                ConfirmPassword = ConfirmPassword.GetPasswordFieldValue()
            };
        }

        public void Register()
        {
            RegisterButton.Click();
        }

        public bool IsRegisterButtonEnabled => RegisterButton.Enabled;

        public void Cancel()
        {
            CancelButton.Click();
        }

        private By LoginLocator => By.CssSelector("[for='username']");

        public InputField LoginName => new InputField(WebDriver, LoginLocator, userParent: true);

        private By FirstNameLocator => By.CssSelector("[for='firstName']");

        public InputField FirstName => new InputField(WebDriver, FirstNameLocator, userParent: true);

        private By LastNameLocator => By.CssSelector("[for='lastName']");

        public InputField LastName => new InputField(WebDriver, LastNameLocator, userParent: true);

        private By PasswordLocator => By.CssSelector("[for='password']");

        public InputField Password => new InputField(WebDriver, PasswordLocator, userParent: true);

        private By ConfirmPasswordLocator => By.CssSelector("[for='confirmPassword']");

        public InputField ConfirmPassword => new InputField(WebDriver, ConfirmPasswordLocator, userParent: true);

        private By RegisterButtonLocator => By.CssSelector(".btn-default");

        private IWebElement RegisterButton => MainContainer.FindElement(RegisterButtonLocator);

        private By CancelButtonLocator => By.CssSelector("[role='button']");

        private IWebElement CancelButton => MainContainer.FindElement(CancelButtonLocator);

        private By SucessMessageLocator => By.CssSelector(".alert-success");

        private IWebElement SucessMessage => MainContainer.FindElement(SucessMessageLocator);

        private By ErrorMessageLocator => By.CssSelector(".result");

        private IWebElement ErrorMessage => MainContainer.FindElement(ErrorMessageLocator);
    }
}
