using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;
using Wpb.CarsRating.Core.WebDriver;

namespace Wpb.CarsRating.Core.PagesObjects
{
    public class Navigator : PageComponent
    {

        public Navigator(IWebDriver webDriver) : base(webDriver)
        {
        }

        public LoginForm LoginForm => new LoginForm(WebDriver);

        public void NavigateTo(string menuItem)
        {
            switch (menuItem)
            {
                case "Home":
                    WebDriver.WaitUntilElementLoads(BuggyRatingHomeLocator, TimeOut);
                    BuggyRatingHome.Click();
                    break;
                case "Register":
                    WebDriver.WaitUntilElementLoads(RegisterLocator, TimeOut);
                    Register.Click();
                    break;
                case "Profile":
                    WebDriver.WaitUntilElementLoads(ProfileLocator, TimeOut);
                    Profile.Click();
                    break;
                default:
                    throw new WebDriverArgumentException($"Unsupported {menuItem}");
            }
        }

        public void Logout()
        {
            LogoutLink.Click();
        }

        public void WaitUntilLoginFormDisappears()
        {
            var webDriverWait = new WebDriverWait(WebDriver, TimeOut);
            var condition = (Func<IWebDriver, bool>)(d => !d.FindElements(LoginFormLocator).Any());
            webDriverWait.Until<bool>(condition);
        }

        public bool LoginFormDisplayed() => Parent.FindElements(LoginFormLocator).Any();

        public bool RegisterButtonDisplayed() => Parent.FindElements(RegisterLocator).Any();

        public bool ProfileLinkDisplayed() => Parent.FindElements(ProfileLocator).Any();

        public bool LogoutButtonDisplayed() => Parent.FindElements(LogoutLocator).Any();

        public string GetGreetingMessage()
        {
            WebDriver.WaitUntilElementLoads(GreetingLocator, TimeOut);
            return Greeting.Text.Trim();
        }

        private By NavBarLocator => By.CssSelector(".navbar");

        private IWebElement Parent => WebDriver.FindElement(NavBarLocator);

        private By BuggyRatingHomeLocator => By.CssSelector(".navbar-brand");

        private IWebElement BuggyRatingHome => Parent.FindElement(BuggyRatingHomeLocator);

        private By RegisterLocator => By.CssSelector(".btn-success-outline");

        private IWebElement Register => Parent.FindElement(RegisterLocator);

        private By ProfileLocator => By.CssSelector("[href*='profile']");

        private IWebElement Profile => Parent.FindElement(ProfileLocator);

        private By LogoutLocator => By.CssSelector("[href*='javascript']");

        private IWebElement LogoutLink => Parent.FindElement(LogoutLocator);

        private By GreetingLocator => By.CssSelector(".nav-link.disabled");

        private IWebElement Greeting => Parent.FindElement(GreetingLocator);

        private By LoginFormLocator => By.CssSelector(".form-inline");
    }
}
