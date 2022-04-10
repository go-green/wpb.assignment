using OpenQA.Selenium;
using System;
using Wpb.CarsRating.Core.Configurations;
using Wpb.CarsRating.Core.WebDriver;

namespace Wpb.CarsRating.Core.PagesObjects
{
    public abstract class BasePage
    {
        protected IWebDriver WebDriver { get; }
        protected TimeSpan TimeOut;
        public BasePage(IWebDriver webDriver)
        {
            TimeOut = AppSettings.Web.TimeOut;
            WebDriver = webDriver;
            WebDriver.WaitForPageToLoad(TimeOut);
        }

        public abstract bool VerifyPage();

        protected IWebElement MainContainer => WebDriver.FindElement(MainContainerLocator);

        protected By MainContainerLocator => By.CssSelector("[role='main']");
    }
}
