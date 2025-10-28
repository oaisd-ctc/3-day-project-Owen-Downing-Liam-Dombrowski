namespace Cards
{
    public class Ace : Card
    {
        protected int cardValue;
        protected string cardName;

        public int CardValue
        {
            get { return cardValue; }
        }

        public string CardName
        {
            get { return cardName; }
        }
}