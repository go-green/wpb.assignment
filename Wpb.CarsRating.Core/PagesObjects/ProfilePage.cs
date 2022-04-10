using OpenQA.Selenium;
using Wpb.CarsRating.Core.WebDriver;

namespace Wpb.CarsRating.Core.PagesObjects
{
    public class ProfilePage : BasePage
    {
        public ProfilePage(IWebDriver webDriver) : base(webDriver)
        {
        }

        public override bool VerifyPage()
        {
            WebDriver.WaitUntilElementLoads(CurrentPasswordLocator, TimeOut);
            WebDriver.WaitUntilElementLoads(NewPasswordLocator, TimeOut);
            WebDriver.WaitUntilElementLoads(ConfirmPasswordLocator, TimeOut);
            WebDriver.WaitUntilElementLoads(SaveButtonLocator, TimeOut);
            return true;
        }

        public void EnterCurrentPassword(string password)
        {
            CurrentPassword.SendKeys(password);
        }

        public void EnterNewPassword(string password)
        {
            NewPassword.SendKeys(password);
            ConfirmPassword.SendKeys(password);
        }

        public void Save()
        {
            SaveButton.Click();
        }

        public string GetSuccessMessage()
        {
            WebDriver.WaitUntilElementLoads(SucessMessageLocator, TimeOut);
            return SuccessMessage.Text.Trim();
        }

        public void ResetPassword(string password, string newpassword)
        {
            EnterCurrentPassword(password);
            EnterNewPassword(newpassword);
            Save();
        }

        private By FormLocator => By.CssSelector(".my-form");

        private IWebElement Parent => MainContainer.FindElement(FormLocator);

        private By SucessMessageLocator => By.CssSelector(".alert-success");

        private IWebElement SuccessMessage => Parent.FindElement(SucessMessageLocator);

        private By CurrentPasswordLocator => By.CssSelector("[name='currentPassword']");

        private IWebElement CurrentPassword => Parent.FindElement(CurrentPasswordLocator);

        private By NewPasswordLocator => By.CssSelector("[name='newPassword']");

        private IWebElement NewPassword => Parent.FindElement(NewPasswordLocator);

        private By ConfirmPasswordLocator => By.CssSelector("[name='newPasswordConfirmation']");

        private IWebElement ConfirmPassword => Parent.FindElement(ConfirmPasswordLocator);

        private By SaveButtonLocator => By.CssSelector("[type='submit']");

        private IWebElement SaveButton => Parent.FindElement(SaveButtonLocator);
    }
}
