using OpenQA.Selenium;
using System;
using Wpb.CarsRating.Core.Configurations;

namespace Wpb.CarsRating.Core.PagesObjects
{
    public class PageComponent
    {
        public IWebDriver WebDriver { get; set; }
        protected TimeSpan TimeOut;
        public PageComponent(IWebDriver webDriver)
        {
            TimeOut = AppSettings.Web.TimeOut;
            WebDriver = webDriver;
        }
    }
}
