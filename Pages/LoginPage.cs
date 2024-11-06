using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace ensek_coding_challenge.Pages
{
    public class LoginPage
    {
        private IWebDriver _driver;

        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
        }

        // Locators for the login page
        private By _usernameField = By.Id("username");
        private By _passwordField = By.Id("password");
        private By _loginButton = By.Id("loginBtn");

        // Actions to perform on the page
        public void EnterUsername(string username)
        {
            _driver.FindElement(_usernameField).SendKeys(username);
        }

        public void EnterPassword(string password)
        {
            _driver.FindElement(_passwordField).SendKeys(password);
        }

        public void ClickLoginButton()
        {
            _driver.FindElement(_loginButton).Click();
        }

        public void Login(string username, string password)
        {
            EnterUsername(username);
            EnterPassword(password);
            ClickLoginButton();
        }
    }
}
