namespace Cards
{
    public class King : Card
    {
        public readonly int cardValue = 10;
        public readonly string cardName = "King";

        //NOT NECESSSARY DUE TO READONLY PROTECTION
        /*public int CardValue
        {
            get { return cardValue; }
        }

        public string CardName
        {
            get { return cardName; }
        }*/

        public override void DrawCardFromDeck()
        {
            Console.WriteLine($"You drew a {cardName}!");
        }
    }
}