using NUnit.Framework;
using ensek_coding_challenge.Base;
using ensek_coding_challenge.Pages;
using ensek_coding_challenge.Utilities;
using OpenQA.Selenium;
using ensek_coding_challenge.AppConfig;

namespace ensek_coding_challenge.Tests 
{
    [TestFixture]
    public class RegistrationTests : BaseTest 
    {

        [Test]
        public void TestLoginWithValidCredentials() 
        {
            // Arrange
            var registerPage = new RegisterPage(myDriver);
            myDriver.Navigate().GoToUrl(Config.BaseUrl + "/Account/Register");

            // Act
            var uniqueUsername = "test.user+" + HelperFunctions.GetUnixTimeStamp() +"@gmail.com";
            registerPage.Register(uniqueUsername, "Password123!");

            // Assert - Check if login was successful by verifying the presence of a dashboard element
            Assert.That(myDriver.Url.Contains("dashboard"), Is.True);
        }

        [Test]
        public void TestLoginWithInvalidEmail() 
        {
            // Arrange
            var registerPage = new RegisterPage(myDriver);
            myDriver.Navigate().GoToUrl(Config.BaseUrl + "/Account/Register");

            // Act
            registerPage.Register("invalid", "Password123!");

            // Assert - Check if login was successful by verifying the presence of a dashboard element
            Assert.That(myDriver.Url.Contains("dashboard"), Is.False);
        }

        [Test]
        public void TestLoginWithInvalidPassword() 
        {
            // Arrange
            var registerPage = new RegisterPage(myDriver);
            myDriver.Navigate().GoToUrl(Config.BaseUrl + "/Account/Register");

            // Act
            var uniqueUsername = "test.user+" + HelperFunctions.GetUnixTimeStamp() +"@gmail.com";
            registerPage.Register(uniqueUsername, "invalid");

            // Assert - Check if login was successful by verifying the presence of a dashboard element
            Assert.That(myDriver.Url.Contains("dashboard"), Is.False);
        }
    }
}
