using Cards;
using NUnit.Framework;
using System;

namespace GamingPlatformTests
{
    [TestFixture]
    class CardsTests
    {
        [Test]
        public void CreateDeck_WhenCalled_DeckOfCardsEquals52Cards()
        {
            DeckOfCards _deck = new DeckOfCards();
            _deck.CreateDeck();
            var expected = 52;
            var actual = _deck.Deck.Length;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ShuffleDeck_WhenCalled_CardsInDeckWereShuffled()
        {
            DeckOfCards _deck = new DeckOfCards();
            _deck.CreateDeck();
            var expected = _deck.Deck;
            _deck.ShuffleDeck();
            var actual = _deck.Deck;
            for (int i = 0; i < expected.Length - 1; i++)
            {
                Assert.AreNotSame(
                    new Tuple<Card.SUIT, Card.VALUE>(expected[i].CardSuit, expected[i].CardValue),
                    new Tuple<Card.SUIT, Card.VALUE>(actual[i].CardSuit, actual[i].CardValue)
                    );
            }
        }
    }
}