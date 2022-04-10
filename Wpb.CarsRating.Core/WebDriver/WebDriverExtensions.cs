using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;

namespace Wpb.CarsRating.Core.WebDriver
{
    public static class WebDriverExtensions
    {
		public static void WaitUntilElementLoads(this IWebDriver webDriver, IWebElement element, TimeSpan timeout)
		{
			var webDriverWait = new WebDriverWait(webDriver, timeout);
			webDriverWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
			var condition = (Func<IWebDriver, bool>)(d => element.Displayed && element.Enabled);
			webDriverWait.Until<bool>(condition);
		}

		public static void WaitUntilElementLoads(this IWebDriver webDriver, By selector, TimeSpan timeout)
		{
			var webDriverWait = new WebDriverWait(webDriver, timeout);
			webDriverWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
			webDriverWait.IgnoreExceptionTypes(typeof(WebDriverException));
			var condition = (Func<IWebDriver, bool>)(d => webDriver.FindElements(selector).Any());
			webDriverWait.Until<bool>(condition);
		}

		public static void WaitForPageToLoad(this IWebDriver driver, TimeSpan timeout)
		{
			var webDriverWait = new WebDriverWait(driver, timeout);
			var javascript = driver as IJavaScriptExecutor;
			var condition = (Func<IWebDriver, bool>)(d =>
			{
				var isLoaded =
					javascript.ExecuteScript("if (document.readyState) return document.readyState;")
						.ToString().ToLower() == "complete";
				return isLoaded;
			});
			webDriverWait.Until<bool>(condition);
		}

		public static void WaitForPageToLoad(this IWebDriver driver, string title, TimeSpan timeout)
		{
			var webDriverWait = new WebDriverWait(driver, timeout);
			var condition = (Func<IWebDriver, bool>)(d => driver.Title.Equals(title));
			webDriverWait.Until<bool>(condition);
		}

		public static IWebElement GetParent(this IWebElement element,IWebDriver driver)
        {
			var javascript = driver as IJavaScriptExecutor;
			return (IWebElement)javascript.ExecuteScript("return arguments[0].parentNode;", element);
		}

		public static void BackspaceClear(this IWebElement element)
		{
			var value = element.GetAttribute("value");
			if (value.Length == 0)
				return;
			element.Clear();
			element.SendKeys(value.Substring(0, 1));
			element.SendKeys(Keys.Backspace);
		}
	}
}
