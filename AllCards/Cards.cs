namespace Cards
{
    public class Card
    {
        public int cardValue;
        public string cardName;
        
        public virtual void DrawCardFromDeck()
        {
            Console.WriteLine("You drew a card!");
        }
    }
}