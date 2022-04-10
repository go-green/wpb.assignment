using OpenQA.Selenium;
using Wpb.CarsRating.Core.WebDriver;

namespace Wpb.CarsRating.Core.PagesObjects
{
    public class HomePage : BasePage
    {
        public HomePage(IWebDriver webDriver) : base(webDriver)
        {
        }

        public override bool VerifyPage()
        {
            WebDriver.WaitUntilElementLoads(PopularMakeLocator, TimeOut);
            WebDriver.WaitUntilElementLoads(PopularModelLocator, TimeOut);
            WebDriver.WaitUntilElementLoads(OverallRatingLocator, TimeOut);
            return true;
        }

        public void GotoPopularMake()
        {
            PopularMake.Click();
        }

        public void GotoPopularModel()
        {
            PopularModel.Click();
        }

        public void GotoOverallRating()
        {
            OverallRating.Click();
        }

        private By PopularMakeLocator => By.CssSelector("[href*='make']");

        private IWebElement PopularMake => MainContainer.FindElement(PopularMakeLocator);

        private By PopularModelLocator => By.CssSelector("[href*='model']");

        private IWebElement PopularModel => MainContainer.FindElement(PopularModelLocator);

        private By OverallRatingLocator => By.CssSelector("[href*='overall']");

        private IWebElement OverallRating => MainContainer.FindElement(OverallRatingLocator);
    }
}
