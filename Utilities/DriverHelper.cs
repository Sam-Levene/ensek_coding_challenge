﻿using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace ensek_coding_challenge.Utilities
{
    public class DriverHelper
    {
        private static IWebDriver? _driver;

        public static IWebDriver GetDriver()
        {
            if (_driver == null)
            {
                var options = new ChromeOptions();
                options.AddArgument("--headless");  // Run tests in headless mode if needed
                options.AddArgument("--start-maximized");
                
                _driver = new ChromeDriver(options);
                _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                _driver.Manage().Window.Maximize();
            }
            return _driver;
        }

        public static void QuitDriver()
        {
            _driver?.Quit();
            _driver = null;
        }
    }
}
