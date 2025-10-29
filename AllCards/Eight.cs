namespace Cards
{
    public class Eight : Card
    {
        public readonly int cardValue = 8;
        public readonly string cardName = "Eight";

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