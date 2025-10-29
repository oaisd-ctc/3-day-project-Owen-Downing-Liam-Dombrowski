namespace Cards
{
    public class Nine : Card
    {
        public readonly int cardValue = 9;
        public readonly string cardName = "Nine";

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