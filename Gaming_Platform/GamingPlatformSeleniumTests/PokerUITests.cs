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
            _driver = new ChromeDriver(@"C:\Users\Bezi\Desktop\AspNetProject\Gaming_Platform\Gaming_Platform\GamePlatform");

        }
        public void Dispose()
        {
            _driver.Quit();
            _driver.Dispose();
        }

        [Fact]
        public void Home_WhenExecuted_ReturnsHomeView()
        {
            _driver.Navigate().GoToUrl("https://localhost:61406/");

            var expected = "Home Page - GamePlatform";
            var actual = _driver.Title;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Home_WhenExecuted_ContainsPokerButon()
        {
            _driver.Navigate().GoToUrl("https://localhost:61406/");

            var expected = "Poker";
            var actual = _driver.FindElement(By.ClassName("poker")).Text;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Poker_WhenExecuted_ReturnsPokerView()
        {
            _driver.Navigate().GoToUrl("https://localhost:61406/");
            _driver.FindElement(By.ClassName("poker")).Click();

            var expected = "https://localhost:61406/Poker/Poker";
            var actual = _driver.Url;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Poker_WhenExecuted_ContainsNewGameButon()
        {
            _driver.Navigate().GoToUrl("https://localhost:61406/");
            _driver.FindElement(By.ClassName("poker")).Click();

            var expected = "New Game";
            var actual = _driver.FindElement(By.Id("newGame")).Text;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Poker_WhenExecuted_ContainsCheckButon()
        {
            _driver.Navigate().GoToUrl("https://localhost:61406/");
            _driver.FindElement(By.ClassName("poker")).Click();

            var expected = "Check";
            var actual = _driver.FindElement(By.Id("checkGame")).Text;

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("changeCard1")]
        [InlineData("changeCard2")]
        [InlineData("changeCard3")]
        [InlineData("changeCard4")]
        [InlineData("changeCard5")]
        public void Poker_WhenExecuted_ContainsChangeCardButons(string id)
        {
            _driver.Navigate().GoToUrl("https://localhost:61406/");
            _driver.FindElement(By.ClassName("poker")).Click();

            var expected = "Change card";
            var actual = _driver.FindElement(By.Id(id)).Text;

            Assert.Equal(expected, actual);
        }
    }
}
