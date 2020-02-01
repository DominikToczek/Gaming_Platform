using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using GamingPlatformTests;
using GamePlatform.Models;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System.Collections;
using System.Linq;
using System.Threading;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;

namespace GamingPlatformTests
{
    [TestFixture]
    class EuroBusinessSelenium
    {
        private IWebDriver _driver;
        private IJavaScriptExecutor js;
        [OneTimeSetUp]
        public void StartBrowser()
        {
            _driver = new ChromeDriver(".");
            js = (IJavaScriptExecutor)_driver;
        }

        [Test]
        public void CheckAddPlayersToGame()
        {
            _driver.Navigate().GoToUrl("http://localhost:61406/");
            _driver.FindElement(By.ClassName("eurobusiness")).Click();
            Thread.Sleep(500);
            _driver.FindElement(By.Id("player-1-name")).Click();
            js.ExecuteScript("document.getElementById('player-1-name').value='Player 1';");
            _driver.FindElement(By.Id("player-2-name")).Click();
            js.ExecuteScript("document.getElementById('player-2-name').value='Player 2';");
            js.ExecuteScript("document.getElementById('add-new-player').click()");
            js.ExecuteScript("document.getElementById('player-3-name').click()");
            js.ExecuteScript("document.getElementById('player-3-name').value='Player 3';");
            js.ExecuteScript("document.querySelector('#add-new-player').click()");
            js.ExecuteScript("document.getElementById('player-4-name').click()");
            js.ExecuteScript("document.getElementById('player-4-name').value='Player 4';");
            js.ExecuteScript("document.querySelector('#add-new-player').click()");
            js.ExecuteScript("document.getElementById('player-5-name').click()");
            js.ExecuteScript("document.getElementById('player-5-name').value='Player 5';");
            js.ExecuteScript("document.querySelector('#add-new-player').click()");
            js.ExecuteScript("document.getElementById('player-6-name').click()");
            js.ExecuteScript("document.getElementById('player-6-name').value='Player 6';");
            js.ExecuteScript("document.querySelector('#add-new-player').click()");
            js.ExecuteScript("document.getElementById('start-game').click()");
            Thread.Sleep(500);
            js.ExecuteScript("document.getElementById('comunication-modal-close-button').click()");
            Assert.That(_driver.FindElement(By.CssSelector(".player-1 .player-name")).Text, Is.EqualTo("Player 1"));
            Assert.That(_driver.FindElement(By.CssSelector(".player-1 .player-money")).Text, Is.EqualTo("10000"));
            Assert.That(_driver.FindElement(By.CssSelector(".player-2 .player-name")).Text, Is.EqualTo("Player 2"));
            Assert.That(_driver.FindElement(By.CssSelector(".player-2 .player-money")).Text, Is.EqualTo("10000"));
            Assert.That(_driver.FindElement(By.CssSelector(".player-3 .player-name")).Text, Is.EqualTo("Player 3"));
            Assert.That(_driver.FindElement(By.CssSelector(".player-3 .player-money")).Text, Is.EqualTo("10000"));
            Assert.That(_driver.FindElement(By.CssSelector(".player-4 .player-name")).Text, Is.EqualTo("Player 4"));
            Assert.That(_driver.FindElement(By.CssSelector(".player-4 .player-money")).Text, Is.EqualTo("10000"));
            Assert.That(_driver.FindElement(By.CssSelector(".player-5 .player-name")).Text, Is.EqualTo("Player 5"));
            Assert.That(_driver.FindElement(By.CssSelector(".player-5 .player-money")).Text, Is.EqualTo("10000"));
            Assert.That(_driver.FindElement(By.CssSelector(".player-6 .player-name")).Text, Is.EqualTo("Player 6"));
            Assert.That(_driver.FindElement(By.CssSelector(".player-6 .player-money")).Text, Is.EqualTo("10000"));
        }

        [Test]
        public void AllFieldsAreNotCompleted()
        {
            IWebElement modal;

            _driver.Navigate().GoToUrl("http://localhost:61406/");
            _driver.FindElement(By.ClassName("eurobusiness")).Click();
            modal = _driver.FindElement(By.Id("alert-not-validate"));



            js.ExecuteScript("document.getElementById('player-1-name').value='Player 1';");
            js.ExecuteScript("document.getElementById('start-game').click()");
            Thread.Sleep(500);
            
            Assert.AreEqual("block", modal.GetCssValue("display"));
        }

        [Test]
        public void AddMoreThan6Players()
        {
            IWebElement modal;

            _driver.Navigate().GoToUrl("http://localhost:61406/EuroBusiness/AddPlayers");
            //_driver.FindElement(By.Id("eurobusiness")).Click();
            modal = _driver.FindElement(By.Id("alert-max-players"));

            js.ExecuteScript("document.getElementById('add-new-player').click()");
            js.ExecuteScript("document.getElementById('add-new-player').click()");
            js.ExecuteScript("document.getElementById('add-new-player').click()");
            js.ExecuteScript("document.getElementById('add-new-player').click()");
            js.ExecuteScript("document.getElementById('add-new-player').click()");
            Thread.Sleep(1500);

            Assert.AreEqual("block", modal.GetCssValue("display"));
        }

        [Test]
        public void UpdateMoney()
        {
            _driver.Navigate().GoToUrl("http://localhost:61406/");
            _driver.FindElement(By.ClassName("eurobusiness")).Click();
            _driver.FindElement(By.Id("player-1-name")).Click();
            js.ExecuteScript("document.getElementById('player-1-name').value='Player 1';");
            _driver.FindElement(By.Id("player-2-name")).Click();
            js.ExecuteScript("document.getElementById('player-2-name').value='Player 2';");
            js.ExecuteScript("document.getElementById('start-game').click()");
            Thread.Sleep(500);
            js.ExecuteScript("document.getElementById('comunication-modal-close-button').click()");

            js.ExecuteScript("addMoney(document.querySelector('.player-container > div.player.player-1'), 500)");
            string money = _driver.FindElement(By.CssSelector(".player-1 .player-money")).Text;

            Assert.AreEqual("10500", money);

        }




        [OneTimeTearDown]
        public void CloseBrowser()
        {
            _driver.Close();
        }


    }
}
