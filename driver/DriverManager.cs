﻿namespace ensek_coding_challenge;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using System;

public class DriverManager
{
    private static IWebDriver? driver;

    public static IWebDriver GetDriver(string browser = "Chrome")
    {
        if (driver == null)
        {
            driver = browser.ToLower() switch
            {
                "chrome" => new ChromeDriver(),
                "firefox" => new FirefoxDriver(),
                "edge" => new EdgeDriver(),
                _ => throw new Exception("Browser not supported"),
            };

            // Setup driver configurations (timeouts, window size, etc.)
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Window.Maximize();
        }
        return driver;
    }

    public static void QuitDriver()
    {
        driver?.Quit();
    }
}

