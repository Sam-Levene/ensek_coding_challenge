namespace ensek_coding_challenge;

using NUnit.Framework;
using OpenQA.Selenium;

[TestFixture]
public class EnsekCodingTest
{
    private IWebDriver driver;
    private HomePage homePage;

    [SetUp]
    public void SetUp()
    {
        // Initialize driver
        driver = DriverManager.GetDriver("chrome");
        homePage = new HomePage(driver);
    }

    [Test]
    public void TestGoogleSearch()
    {
        ExtentReportManager.CreateTest("GoogleSearchTest");

        driver.Navigate().GoToUrl("https://www.google.com");

        // Log the search action
        ExtentReportManager.LogInfo("Performing Google Search");

        homePage.Search("Selenium WebDriver");

        Assert.Equals(driver.PageSource.Contains("Selenium"), true);

        ExtentReportManager.LogPass("Test Passed");
    }

    [TearDown]
    public void TearDown()
    {
        DriverManager.QuitDriver();
    }
}
