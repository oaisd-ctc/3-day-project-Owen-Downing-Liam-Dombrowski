using System.Security.AccessControl;
using Cards;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Hello gamblers!");
		
		
		Ace newCard = new Ace(); //Testing card protection
		// This will fail due to card protections; newCard.cardValue = 15;
		Console.WriteLine(newCard.cardValue);
    }

	public object DrawCard()
	{
		Random random = new Random();
		int cardIndex = random.Next(0, deckList.Length);

		return deckList[cardIndex];
		deckList.Remove(deckList[cardIndex]);
	}
}