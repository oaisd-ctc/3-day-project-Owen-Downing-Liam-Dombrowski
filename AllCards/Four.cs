namespace Cards
{
    public class Four : Card
    {
        public readonly int cardValue = 4;
        public readonly string cardName = "Four";

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