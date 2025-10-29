namespace Cards
{
    public class Six : Card
    {
        public readonly int cardValue = 6;
        public readonly string cardName = "Six";

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