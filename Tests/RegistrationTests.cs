using NUnit.Framework;
using ensek_coding_challenge.Base;
using ensek_coding_challenge.Pages;
using ensek_coding_challenge.Utilities;
using OpenQA.Selenium;
using ensek_coding_challenge.AppConfig;
using AventStack.ExtentReports;

namespace ensek_coding_challenge.Tests 
{
    [TestFixture]
    public class RegistrationTests : BaseTest 
    {

        [Test]
        public void TestLoginWithValidCredentials() 
        {
            try {
            // Arrange
            var registerPage = new RegisterPage(myDriver);
            extentTest.Log(Status.Info, "Test Step 1: Opening the browser");
            myDriver.Navigate().GoToUrl(Config.BaseUrl + "/Account/Register");

            // Act
            var uniqueUsername = "test.user+" + HelperFunctions.GetUnixTimeStamp() +"@gmail.com";
            registerPage.Register(uniqueUsername, "Password123!");
            extentTest.Log(Status.Info, "Test Step 2: Register using valid details");

            // Assert - Check if login was successful by verifying the presence of a dashboard element
            Assert.That(myDriver.Url.Contains("dashboard"), Is.True);
            extentTest.Log(Status.Pass, "Test Result: Passed successfully");
            } catch (Exception myException) {
                // Capture a screenshot on failure
                string screenshotPath = HelperFunctions.CaptureScreenshot("fail_" + HelperFunctions.GetUnixTimeStamp(), myDriver);
                extentTest.AddScreenCaptureFromPath(screenshotPath);

                extentTest.Log(Status.Fail, "Test failed: " + myException.Message);
                throw; // re-throw the exception to mark the test as failed
            }
        }

        [Test]
        public void TestLoginWithInvalidEmail() 
        {
             try {
                // Arrange
                var registerPage = new RegisterPage(myDriver);
                extentTest.Log(Status.Info, "Test Step 1: Opening the browser");
                myDriver.Navigate().GoToUrl(Config.BaseUrl + "/Account/Register");

                // Act
                registerPage.Register("invalid", "Password123!");
                extentTest.Log(Status.Info, "Test Step 2: Register using invalid username");

                // Assert - Check if login was successful by verifying the presence of a dashboard element
                Assert.That(myDriver.Url.Contains("dashboard"), Is.False);
                extentTest.Log(Status.Pass, "Test Result: Passed successfully");
            } catch (Exception myException) {
                // Capture a screenshot on failure
                string screenshotPath = HelperFunctions.CaptureScreenshot("fail_" + HelperFunctions.GetUnixTimeStamp(), myDriver);
                extentTest.AddScreenCaptureFromPath(screenshotPath);

                extentTest.Log(Status.Fail, "Test failed: " + myException.Message);
                throw; // re-throw the exception to mark the test as failed
            }
        }

        [Test]
        public void TestLoginWithInvalidPassword() 
        {
            try {
                // Arrange
                var registerPage = new RegisterPage(myDriver);
                extentTest.Log(Status.Info, "Test Step 1: Opening the browser");
                myDriver.Navigate().GoToUrl(Config.BaseUrl + "/Account/Register");

                // Act
                var uniqueUsername = "test.user+" + HelperFunctions.GetUnixTimeStamp() +"@gmail.com";
                registerPage.Register(uniqueUsername, "invalid");
                extentTest.Log(Status.Info, "Test Step 2: Register using invalid password");

                // Assert - Check if login was successful by verifying the presence of a dashboard element
                Assert.That(myDriver.Url.Contains("dashboard"), Is.False);
                extentTest.Log(Status.Pass, "Test Result: Passed successfully");
            } catch (Exception myException) {
                // Capture a screenshot on failure
                string screenshotPath = HelperFunctions.CaptureScreenshot("fail_" + HelperFunctions.GetUnixTimeStamp(), myDriver);
                extentTest.AddScreenCaptureFromPath(screenshotPath);

                extentTest.Log(Status.Fail, "Test failed: " + myException.Message);
                throw; // re-throw the exception to mark the test as failed
            }
        }
    }
}
