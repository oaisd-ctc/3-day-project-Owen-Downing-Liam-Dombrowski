namespace Cards
{
    public class Ace : Card
    {
        protected int cardValue = 11;
        protected string cardName = "Ace";

        public int CardValue
        {
            get { return cardValue; }
        }

        public string CardName
        {
            get { return cardName; }
        }
}