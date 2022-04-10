using BoDi;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using Wpb.CarsRating.Core.ApiServices;
using Wpb.CarsRating.Core.ApiServices.Contracts;
using Wpb.CarsRating.Core.Configurations;
using Wpb.CarsRating.Core.WebDriver;

namespace Wpb.CarsRating.Core.Hooks
{
    [Binding]
    public class BeforeAfterScenario
    {
        private readonly IObjectContainer _objectContainer;
        private IWebDriver _webDriver = null;

        public BeforeAfterScenario(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
        }

        [BeforeScenario(Order = 0)]
        public void BeforeScenario()
        {
            RegisterServices();
            RegisterWebDriver();
            _webDriver.Manage().Window.Maximize();
        }

        private void RegisterWebDriver()
        {
            _webDriver = new WebDriverFactory().Create(AppSettings.Web.TargetBrowser, AppSettings.Web.SeleniumGrid);
            _objectContainer.RegisterInstanceAs<IWebDriver>(_webDriver);
        }

        // Register API service dependencies 
        private void RegisterServices()
        {
            _objectContainer.RegisterTypeAs<RestClient, IRest>();
            _objectContainer.RegisterTypeAs<UserApiClient, IUser>();
        }

        [AfterScenario(Order = 0)]
        public void AfterScenario()
        {
            DisposeWebDriver();
        }

        private void DisposeWebDriver()
        {
            if (!_objectContainer.IsRegistered<IWebDriver>()) return;
            _webDriver.Quit();
            _webDriver.Dispose();
        }
    }
}
