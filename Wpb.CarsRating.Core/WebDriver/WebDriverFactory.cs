using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;
using System.IO;

namespace Wpb.CarsRating.Core.WebDriver
{
    public class WebDriverFactory
    {
        public IWebDriver Create(string key, string gridUrl = null)
        {
            switch (key)
            {
                case "Chrome":
                    return new ChromeDriver(Path.Combine(Directory.GetCurrentDirectory(),"WebDriver"));
                case "Remote":
                    return new RemoteWebDriver(new Uri(gridUrl),
                        new ChromeOptions().ToCapabilities());
                default:
                    throw new InvalidOperationException($"Target browser {key} is not supported");
            }
        }
    }
}

