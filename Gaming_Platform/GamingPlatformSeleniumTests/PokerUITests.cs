using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using Xunit;

namespace GamingPlatformSeleniumTests
{
    public class PokerUITests : IDisposable
    {
        private readonly IWebDriver _driver;

        public PokerUITests()
        {
            _driver = new ChromeDriver();

        }
        public void Dispose()
        {
            _driver.Quit();
            _driver.Dispose();
        }

        [Fact]
        public void Test1()
        {

        }
    }
}
