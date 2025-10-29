namespace Cards
{
    public class Ace : Card
    {
        public readonly int cardValue = 11;
        public readonly string cardName = "Ace";

        //NOT NECESSSARY DUE TO READONLY PROTECTION
        /*public int CardValue
        {
            get { return cardValue; }
        }

        public string CardName
        {
            get { return cardName; }
        }*/
    }
}