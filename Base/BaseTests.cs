using NUnit.Framework;
using ensek_coding_challenge.Utilities;
using OpenQA.Selenium;
using AventStack.ExtentReports;

namespace ensek_coding_challenge.Base
{
    public class BaseTest
    {
        protected IWebDriver myDriver;
        protected ExtentTest extentTest;

        [SetUp]
        public void Setup()
        {
            var extent = ExtentReportManager.GetExtentReport();
            extentTest = extent.CreateTest("Sample Test");
            myDriver = DriverHelper.GetDriver();
        }

        [TearDown]
        public void TearDown()
        {
            DriverHelper.QuitDriver();
            ExtentReportManager.FlushReport();
        }
    }
}
