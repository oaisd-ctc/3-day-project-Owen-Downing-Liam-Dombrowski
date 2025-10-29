using Cards;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Hello gamblers!");
    }

	public object DrawCard()
	{
		Random random = new Random();
		int cardIndex = random.Next(0, deckList.Length);

		return deckList[cardIndex];
		deckList.Remove(deckList[cardIndex]);
	}

	public void PlayGame()
	{
		object dealerCard = DrawCard();
		object dealerHiddenCard = DrawCard();
		Console.WriteLine($"The dealer drew a {dealerCard.GetName()} and a hidden card.");

		object playerCard1 = DrawCard();
		object playerCard2 = DrawCard();
		Console.WriteLine($"You drew a {playerCard1.GetName()} and a {playerCard2.GetName()}.")
		int handValue = playerCard1.GetValue() + playerCard2.GetValue();

		PlayerTurn();

	}
}
