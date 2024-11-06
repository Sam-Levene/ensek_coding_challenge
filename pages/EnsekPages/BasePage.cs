namespace ensek_coding_challenge;

using OpenQA.Selenium;
using System;

public class BasePage(IWebDriver driver)
{
    protected IWebDriver driver = driver;

    protected IWebElement FindElement(By locator)
    {
        return driver.FindElement(locator);
    }

    protected void Click(By locator)
    {
        FindElement(locator).Click();
    }

    protected void SendKeys(By locator, string text)
    {
        FindElement(locator).SendKeys(text);
    }

    protected string GetText(By locator)
    {
        return FindElement(locator).Text;
    }

    protected void WaitForElementToBeVisible(By locator, TimeSpan timeout)
    {
        new OpenQA.Selenium.Support.UI.WebDriverWait(driver, timeout).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator));
    }
}
