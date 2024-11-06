namespace ensek_coding_challenge;

using OpenQA.Selenium;

public class HomePage(IWebDriver driver) : ensek_coding_challenge.BasePage(driver)
{
    private readonly By searchBox = By.Name("q");
    private readonly By searchButton = By.Name("btnK");

    public void Search(string searchText)
    {
        SendKeys(searchBox, searchText);
        Click(searchButton);
    }
}
