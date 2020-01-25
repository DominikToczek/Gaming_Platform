using Cards;
using FiveCardsPoker;
using NUnit.Framework;
using System;

namespace GamingPlatformTests
{
    [TestFixture]
    class FiveCardsPokerTests
    {
        [Test]
        public void GetPlayerHand_WhenPlayerHandIsNull_NullReferenceExceptionThrown()
        {
            Deal _deal = new Deal();
            Assert.That(_deal.GetPlayerHand, Throws.TypeOf<NullReferenceException>());
        }

        [Test]
        public void GetComputerHand_WhenComputerHandIsNull_NullReferenceExceptionThrown()
        {
            Deal _deal = new Deal();
            Assert.That(_deal.GetComputerHand, Throws.TypeOf<NullReferenceException>());
        }

        [Test]
        public void GetSortedPlayerHand_WhenPlayerHandIsNull_NullReferenceExceptionThrown()
        {
            Deal _deal = new Deal();
            Assert.That(_deal.GetSortedPlayerHand, Throws.TypeOf<NullReferenceException>());
        }

        [Test]
        public void GetSortedComputerHand_WhenComputerHandIsNull_NullReferenceExceptionThrown()
        {
            Deal _deal = new Deal();
            Assert.That(_deal.GetSortedComputerHand, Throws.TypeOf<NullReferenceException>());
        }

        [Test]
        public void DealCards_WhenCalled_DeckOfCardsCreated()
        {
            Deal _deal = new Deal();
            _deal.DealCards();
            var actual = _deal.Deck.Length;
            var expected = 52;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void DealCards_WhenCalled_PlayerHandCreated()
        {
            Deal _deal = new Deal();
            _deal.DealCards();
            var actual = _deal.GetPlayerHand().Length;
            var expected = 5;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void DealCards_WhenCalled_ComputerHandCreated()
        {
            Deal _deal = new Deal();
            _deal.DealCards();
            var actual = _deal.GetComputerHand().Length;
            var expected = 5;
            Assert.AreEqual(expected, actual);
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(5)]
        public void ChangeCard_SelectCardNumber_CardChanged(int cardNumber)
        {
            Deal _deal = new Deal();
            _deal.DealCards();
            var hand = _deal.GetPlayerHand();
            var expected = new Tuple<Card.SUIT, Card.VALUE>(hand[cardNumber - 1].CardSuit, hand[cardNumber - 1].CardValue);
            _deal.ChangeCard(cardNumber);
            hand = _deal.GetPlayerHand();
            var actual = new Tuple<Card.SUIT, Card.VALUE>(hand[cardNumber - 1].CardSuit, hand[cardNumber - 1].CardValue);
            Assert.AreNotEqual(expected, actual);
        }

        [Test]
        public void SortCards_SortPlayerCards_CardsSortedByValue()
        {
            Deal _deal = new Deal();
            _deal.DealCards();
            _deal.SortCards();
            var sortedHand = _deal.GetSortedPlayerHand();

            for (int i = 0; i < sortedHand.Length - 2; i++)
            {
                Assert.LessOrEqual(sortedHand[i].CardValue, sortedHand[i + 1].CardValue);
            }
        }
    }
}