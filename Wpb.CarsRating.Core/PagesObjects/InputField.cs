using OpenQA.Selenium;
using System.Linq;
using Wpb.CarsRating.Core.WebDriver;

namespace Wpb.CarsRating.Core.PagesObjects
{
    public class InputField : PageComponent
    {
        private By _parent;
        private bool _userParent;

        public InputField(IWebDriver webDriver, By parent, bool userParent = false)
            : base(webDriver)
        {
            _parent = parent;
            _userParent = userParent;
        }


        public bool IsFieldInError => Parent.FindElements(FieldErrorLocator).Any();

        public string GetFieldError()
        {
            if (Parent.FindElements(ErrorMessageLocator).Any())
            {
                var element = Parent.FindElement(ErrorMessageLocator);
                var hiddenAttribute = element.GetAttribute("hidden");
                if (hiddenAttribute == null)
                    return element.Text.Trim();
            }
            throw new ElementNotVisibleException("The field is not in error");
        }


        public void Enter(string text)
        {
            TextInput.Clear();
            TextInput.SendKeys(text);
        }


        public void EnterPassword(string text)
        {
            PasswordInput.Clear();
            PasswordInput.SendKeys(text);
        }


        public string GetTextFieldValue()
        {
            return TextInput.GetAttribute("value");
        }


        public void ClearTextField()
        {
            TextInput.BackspaceClear();
        }


        public void ClearPasswordField()
        {
            PasswordInput.BackspaceClear();
        }


        public string GetPasswordFieldValue()
        {
            return PasswordInput.GetAttribute("value");
        }


        private IWebElement Parent => _userParent ? WebDriver.FindElement(_parent).GetParent(WebDriver) : WebDriver.FindElement(_parent);

        private By ErrorMessageLocator => By.CssSelector("div.alert-danger");

        private By FieldErrorLocator => By.CssSelector("input.ng-invalid");

        private By TextInputLocator => By.CssSelector("[type='text']");

        private IWebElement TextInput => Parent.FindElement(TextInputLocator);

        private By PasswordInputLocator => By.CssSelector("[type='password']");

        private IWebElement PasswordInput => Parent.FindElement(PasswordInputLocator);
    }
}
