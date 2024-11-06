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
        driver.Navigate().GoToUrl("https://www.google.com");

        // Perform search action using page object
        homePage.Search("Selenium WebDriver");

        // Verify the result
        Assert.Equals(driver.PageSource.Contains("Selenium"), true);
    }

    [TearDown]
    public void TearDown()
    {
        DriverManager.QuitDriver();
    }
}
