using NUnit.Framework;
using ensek_coding_challenge.Utilities;
using OpenQA.Selenium;

namespace ensek_coding_challenge.Base
{
    public class BaseTest
    {
        protected IWebDriver myDriver;

        [SetUp]
        public void Setup()
        {
            myDriver = DriverHelper.GetDriver();
        }

        [TearDown]
        public void TearDown()
        {
            DriverHelper.QuitDriver();
        }
    }
}
