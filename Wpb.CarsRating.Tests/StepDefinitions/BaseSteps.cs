using OpenQA.Selenium;
using Wpb.CarsRating.Core.ContextObjects;

namespace Wpb.CarsRating.Tests.StepDefinitions
{
    public class BaseSteps : TechTalk.SpecFlow.Steps
    {
        protected IWebDriver WebDriver { get; }
        protected ContextInitializer Context { get; }
        public BaseSteps(IWebDriver webDriver, ContextInitializer context)
        {
            WebDriver = webDriver;
            Context = context;
        }
    }
}
