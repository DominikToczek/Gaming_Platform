using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using NUnit.Framework;

namespace GamingPlatformSeleniumTests
{
    public class PokerUITests : IDisposable
    {
        private IWebDriver _driver;

        [OneTimeSetUp]
        public void StartBrowser()
        {
            _driver = new ChromeDriver(@"C:\Users\Bezi\Desktop\AspNetProject\Gaming_Platform\Gaming_Platform\GamePlatform");

        }
        [OneTimeTearDown]
        public void Dispose()
        {
            _driver.Quit();
            _driver.Dispose();
        }

        [Test]
        public void Home_WhenExecuted_ReturnsHomeView()
        {
            _driver.Navigate().GoToUrl("http://localhost:61406/");

            var expected = "Home Page - GamePlatform";
            var actual = _driver.Title;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Home_WhenExecuted_ContainsPokerButon()
        {
            _driver.Navigate().GoToUrl("http://localhost:61406/");

            var expected = "Poker";
            var actual = _driver.FindElement(By.ClassName("poker")).Text;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Poker_WhenExecuted_ReturnsPokerView()
        {
            _driver.Navigate().GoToUrl("http://localhost:61406/");
            _driver.FindElement(By.ClassName("poker")).Click();

            var expected = "http://localhost:61406/Poker/Poker";
            var actual = _driver.Url;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Poker_WhenExecuted_ContainsNewGameButon()
        {
            _driver.Navigate().GoToUrl("http://localhost:61406/");
            _driver.FindElement(By.ClassName("poker")).Click();

            var expected = "New Game";
            var actual = _driver.FindElement(By.Id("newGame")).Text;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Poker_WhenExecuted_ContainsCheckButon()
        {
            _driver.Navigate().GoToUrl("http://localhost:61406/");
            _driver.FindElement(By.ClassName("poker")).Click();

            var expected = "Check";
            var actual = _driver.FindElement(By.Id("checkGame")).Text;

            Assert.AreEqual(expected, actual);
        }

        
        [TestCase("changeCard1")]
        [TestCase("changeCard2")]
        [TestCase("changeCard3")]
        [TestCase("changeCard4")]
        [TestCase("changeCard5")]
        public void Poker_WhenExecuted_ContainsChangeCardButons(string id)
        {
            _driver.Navigate().GoToUrl("http://localhost:61406/");
            _driver.FindElement(By.ClassName("poker")).Click();

            var expected = "Change card";
            var actual = _driver.FindElement(By.Id(id)).Text;

            Assert.AreEqual(expected, actual);
        }
    }
}
