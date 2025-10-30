using System.Net;
using System.Security.AccessControl;
using Cards;

public class Program
{
	public static void Main(string[] args)
	{
		Console.WriteLine("Hello gamblers!");
		PlayGame();
	}

	//Initialize the 3D card array

	public readonly static int[,] baselineDeck = { { 11, 0 }, { 2, 0 }, { 3, 0 }, { 4, 0 }, { 5, 0 }, { 6, 0 }, { 7, 0 }, { 8, 0 }, { 9, 0 }, { 10, 0 }, { 10, 1 }, { 10, 2 }, { 10, 3 } };
	public static int handValue;

	public static object DrawCard()
	{
		Random random = new Random();
		int cardIndex = random.Next(0, 13);

		return baselineDeck[cardIndex,0];
		//deckList.Remove(deckList[cardIndex]);
	}

	public static void PlayGame()
	{
		object dealerCard = DrawCard();
		object dealerHiddenCard = DrawCard();
		Console.WriteLine($"The dealer drew a {dealerCard} and a hidden card.");

		int playerCard1 = Convert.ToInt32(DrawCard());
		int playerCard2 = Convert.ToInt32(DrawCard());
		Console.WriteLine($"You drew a {playerCard1} and a {playerCard2}.");
		handValue = (playerCard1 + playerCard2);
		Console.WriteLine($"Your hand value is now {handValue}.");

		//PlayerTurn();
	}

	/*public void PlayerTurn()
	{
		if (handValue > 21)
			{
				Console.WriteLine($"You busted with {handValue}! The dealer wins!");
				//Function to move to next game, not sure how we want to move it forward
			}
		else if (handValue == 21)
		{
			Console.WriteLine($"You got 21! Now its up to the dealer.");
			DealerTurn();
		}
		else 
		{
			Console.WriteLine($"Your hand value is {handValue}. Would you like to hit or stand? (H / S)");
			if (Console.ReadLine() = "H" || Console.ReadLine() = "Hit")
			{
				PlayerHit();
			}
			else if (Console.ReadLine() = "S" || Console.ReadLine() = "Stand")
			{
				Console.WriteLine($"Your final hand value is {handValue}.");
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
	}*/
}
