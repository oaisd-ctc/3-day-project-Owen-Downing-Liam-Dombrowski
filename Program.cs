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
		Console.WriteLine($"The dealer drew a {dealerCard.cardName} and a hidden card.");

		object playerCard1 = DrawCard();
		object playerCard2 = DrawCard();
		Console.WriteLine($"You drew a {playerCard1.cardName} and a {playerCard2.cardName}.")
		int handValue = playerCard1.cardValue + playerCard2.cardValue;

		PlayerTurn();
	}

	public void PlayerTurn()
	{
		if (handValue > 21)
			{
				Console.WriteLine($"You busted with {handValue}! The dealer wins!");
				//Function to move to next game, not sure how we want to move it forward
			}
		if else (handValue == 21)
		{
			Console.WriteLine($"You got 21! Now its up to the dealer.");
			DealerTurn();
		}
		else 
		{
			Console.WriteLine($"Your hand value is {handValue}. Would you like to hit or stand? (H / S)")
			if (Console.ReadLine() = "H" || Console.ReadLine() = "Hit")
			{
				PlayerHit();
			}
			if else (Console.ReadLine() = "S" || Console.ReadLine() = "Stand")
			{
				Console.WriteLine($"Your final hand value is {handValue}.")
				DealerTurn();
			}
		}
	}

	public void PlayerHit()
	{
		object newCard = DrawCard();
		Console.WriteLine($"You drew a {newCard.cardName}!");
		handValue = handValue + newCard.cardValue;
		PlayerTurn();
	}
}
