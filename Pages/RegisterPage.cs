using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace ensek_coding_challenge.Pages 
{
    public class RegisterPage 
    {
        private IWebDriver _driver;

        public RegisterPage(IWebDriver driver) 
        {
            _driver = driver;
        }

        // Locators for the login page
        private readonly By _usernameField = By.Id("Email");
        private readonly By _passwordField = By.Id("Password");
        private readonly By _passwordConfirmationField = By.Id("ConfirmPassword");
        private readonly By _registrationButton = By.XPath("/html/body/div[2]/form/div[5]/div/input");
        // Actions to perform on the page
        private void EnterUsername(string username) 
        {
            _driver.FindElement(_usernameField).SendKeys(username);
        }

        public void EnterPassword(string password) 
        {
            _driver.FindElement(_passwordField).SendKeys(password);
        }

        public void ConfirmPassword(string password) 
        {
            _driver.FindElement(_passwordConfirmationField).SendKeys(password);
        }

        public void ClickRegisterButton() 
        {
            _driver.FindElement(_registrationButton).Click();
        }

        public void Register(string username, string password) 
        {
            EnterUsername(username);
            EnterPassword(password);
            ConfirmPassword(password);
            ClickRegisterButton();
        }
    }
}
