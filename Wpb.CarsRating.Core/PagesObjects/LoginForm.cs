using OpenQA.Selenium;
using Wpb.CarsRating.Core.WebDriver;

namespace Wpb.CarsRating.Core.PagesObjects
{
    public class LoginForm : PageComponent
    {
        public LoginForm(IWebDriver webDriver) : base(webDriver)
        {
        }

        public void Login(string username, string password)
        {
            EnterCredential(username, password);
            Login();
        }

        public void EnterCredential(string username, string password)
        {
            WebDriver.WaitUntilElementLoads(UsernameLocator, TimeOut);
            WebDriver.WaitUntilElementLoads(PasswordLocator, TimeOut);
            Username.SendKeys(username);
            Password.SendKeys(password);
        }

        public void Login()
        {
            LoginButton.Click();
        }

        public string GetLoginError()
        {
            WebDriver.WaitUntilElementLoads(LoginErrorLocator, TimeOut);
            return LoginError.Text.Trim();
        }

        private By FormLocator => By.CssSelector(".form-inline");

        private IWebElement Parent => WebDriver.FindElement(FormLocator);

        private By UsernameLocator => By.CssSelector("[name='login']");

        private IWebElement Username => Parent.FindElement(UsernameLocator);

        private By PasswordLocator => By.CssSelector("[name='password']");

        private IWebElement Password => Parent.FindElement(PasswordLocator);

        private By LoginButtonLocator => By.CssSelector("[type='submit']");

        private IWebElement LoginButton => Parent.FindElement(LoginButtonLocator);

        private By LoginErrorLocator => By.CssSelector(".label-warning");

        private IWebElement LoginError => Parent.FindElement(LoginErrorLocator);
    }
}
