using NUnit.Framework;
using ensek_coding_challenge.Base;
using ensek_coding_challenge.Pages;
using OpenQA.Selenium;

namespace ensek_coding_challenge.Tests
{
    [TestFixture]
    public class EnsekCodingLoginTests : BaseTest
    {
        [Test]
        public void TestLoginWithValidCredentials()
        {
            // Arrange
            var loginPage = new LoginPage(myDriver);
            myDriver.Navigate().GoToUrl("https://example.com/login");

            // Act
            loginPage.Login("testuser", "password123");

            // Assert - Check if login was successful by verifying the presence of a dashboard element
            Assert.Equals(myDriver.Url.Contains("dashboard"), true);
        }

        [Test]
        public void TestLoginWithInvalidCredentials()
        {
            // Arrange
            var loginPage = new LoginPage(myDriver);
            myDriver.Navigate().GoToUrl("https://example.com/login");

            // Act
            loginPage.Login("invaliduser", "wrongpassword");

            // Assert - Check if an error message appears
            var errorMessage = myDriver.FindElement(By.Id("errorMessage"));
            Assert.Equals(errorMessage.Displayed, true);
        }
    }
}
