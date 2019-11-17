using Cards;
using System;

namespace FiveCardsPoker
{
    public class Layout
    {
        public int HandValue { get; set; } = 0;
        private int heartsSum = 0, diamondsSum = 0, spadesSum = 0, clubsSum = 0;

        private Card[] sortedHand;

        public Hand CardsLayout(Card[] hand)
        {
            GetSortedHand(hand);
            GetSum(sortedHand);

            if (IsRoyalFlush(sortedHand))
                return Hand.RoyalFlush;
            else if (IsStraightFlush(sortedHand))
                return Hand.StraightFlush;
            else if (IsFourOfKind(sortedHand))
                return Hand.FourOfKind;
            else if (IsFullHouse(sortedHand))
                return Hand.FullHouse;
            else if (IsFlush(sortedHand))
                return Hand.Flush;
            else if (IsStraight(sortedHand))
                return Hand.Straight;
            else if (IsThreeOfKind(sortedHand))
                return Hand.ThreeOfKind;
            else if (IsTwoPair(sortedHand))
                return Hand.TwoPair;
            else if (IsOnePair(sortedHand))
                return Hand.OnePair;
            else return Hand.HighCard;
        }

        private void HandOfSortedCards()
        {
            sortedHand = new Card[5];
        }

        private void GetSortedHand(Card[] hand)
        {
            HandOfSortedCards();
            int i = 0;
            foreach (var card in hand)
            {
                sortedHand[i] = card;
                i++;
            }
        }

        private void GetSum(Card[] hand)
        {
            for (int i = 0; i < 5; i++)
            {
                if (hand[i].CardSuit == Card.SUIT.HEARTS)
                    heartsSum++;
                else if (hand[i].CardSuit == Card.SUIT.DIAMONDS)
                    diamondsSum++;
                else if (hand[i].CardSuit == Card.SUIT.CLUBS)
                    clubsSum++;
                else spadesSum++;
            }
        }

        private bool IsRoyalFlush(Card[] hand)
        {
            if (IsFlush(sortedHand))
                if (IsStraight(sortedHand) && sortedHand[0].CardValue == Card.VALUE.TEN)
                {
                    HandValue = 1000 + (int)sortedHand[4].CardValue;
                    return true;
                }
                else return false;
            else return false;
        }

        private bool IsStraightFlush(Card[] hand)
        {
            if (IsFlush(sortedHand))
                if (IsStraight(sortedHand))
                {
                    HandValue = 900 + (int)sortedHand[4].CardValue;
                    return true;
                }
                else return false;
            else return false;
        }

        private bool IsFourOfKind(Card[] hand)
        {
            if (hand[0].CardValue == hand[3].CardValue || hand[1].CardValue == hand[4].CardValue)
            {
                HandValue = 800 + (int)hand[3].CardValue;
                return true;
            }
            else return false;
        }

        private bool IsFullHouse(Card[] hand)
        {
            if (hand[0].CardValue == hand[2].CardValue && hand[3].CardValue == hand[4].CardValue)
            {
                HandValue = 700 + (int)hand[2].CardValue;
                return true;
            }
            else if (hand[0].CardValue == hand[1].CardValue && hand[2].CardValue == hand[4].CardValue)
            {
                HandValue = 700 + (int)hand[4].CardValue;
                return true;
            }
            else return false;
        }

        private bool IsFlush(Card[] hand)
        {
            if (heartsSum == 5 || diamondsSum == 5 || spadesSum == 5 || clubsSum == 5)
            {
                HandValue = 600 + (int)hand[4].CardValue;
                return true;
            }
            else return false;
        }

        private bool IsStraight(Card[] hand)
        {
            if (hand[0].CardValue == hand[1].CardValue - 1 &&
                hand[1].CardValue == hand[2].CardValue - 1 &&
                hand[2].CardValue == hand[3].CardValue - 1 &&
                hand[3].CardValue == hand[4].CardValue - 1)
            {
                HandValue = 500 + (int)hand[4].CardValue;
                return true;
            }
            else return false;
        }

        private bool IsThreeOfKind(Card[] hand)
        {
            if ((hand[0].CardValue == hand[2].CardValue) ||
                (hand[1].CardValue == hand[3].CardValue) ||
                (hand[2].CardValue == hand[4].CardValue))
            {
                HandValue = 400 + (int)hand[2].CardValue;
                return true;
            }
            else return false;
        }

        private bool IsTwoPair(Card[] hand)
        {
            if ((hand[0].CardValue == hand[1].CardValue && hand[2].CardValue == hand[3].CardValue) ||
                (hand[0].CardValue == hand[1].CardValue && hand[3].CardValue == hand[4].CardValue) ||
                (hand[1].CardValue == hand[2].CardValue && hand[3].CardValue == hand[4].CardValue))
            {
                HandValue = 300 + Math.Max((int)hand[1].CardValue, (int)hand[3].CardValue);
                return true;
            }
            else return false;
        }

        private bool IsOnePair(Card[] hand)
        {
            if (hand[0].CardValue == hand[1].CardValue)
            {
                HandValue = 200 + (int)hand[1].CardValue;
                return true;
            }
            else if (hand[1].CardValue == hand[2].CardValue)
            {
                HandValue = 200 + (int)hand[2].CardValue;
                return true;
            }
            else if (hand[2].CardValue == hand[3].CardValue)
            {
                HandValue = 200 + (int)hand[3].CardValue;
                return true;
            }
            else if (hand[3].CardValue == hand[4].CardValue)
            {
                HandValue = 200 + (int)hand[4].CardValue;
                return true;
            }
            else return false;
        }
    }

    public enum Hand : int
    {
        HighCard,
        OnePair,
        TwoPair,
        ThreeOfKind,
        Straight,
        Flush,
        FullHouse,
        FourOfKind,
        StraightFlush,
        RoyalFlush
    }
}