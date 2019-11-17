namespace Cards
{
    public class Card
    {
        public SUIT CardSuit { get; set; }
        public VALUE CardValue { get; set; }

        public enum SUIT
        {
            HEARTS,
            DIAMONDS,
            CLUBS,
            SPADES
        }

        public enum VALUE
        {
            TWO,
            THREE,
            FOUR,
            FIVE,
            SIX,
            SEVEN,
            EIGHT,
            NINE,
            TEN,
            JACK,
            QUEEN,
            KING,
            ACE
        }
    }
}