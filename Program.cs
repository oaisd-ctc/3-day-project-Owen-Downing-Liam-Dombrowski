using System.Net;
using System.Security.AccessControl;
using Cards;

public class Program
{
	public static void Main(string[] args)
	{
		Console.Clear();
		Console.WriteLine("Hello gamblers!");
		RandomizePlayDeck();
		PlayGame();
	}

	//Initialize the 3D card array

	public readonly static int[] baselineDeck = { 11, 2, 3, 4, 5, 6, 7, 8, 9, 10, 10, 10, 10 };
	public static int[] inPlayDeck = new int[13];
	public static int cardPullProgress; //Keeps track of where in the array it is pulling a card. Because the array is already shuffled, we don't need to use random pulling, but we must keep track of progress because of this.
	
	public static void RandomizePlayDeck()
	{
		Random rand = new Random();
		baselineDeck.CopyTo(inPlayDeck, 0);
		rand.Shuffle(inPlayDeck);
		cardPullProgress = 0;
		handValue = 0;
    }
	public static int handValue;

	public static int DrawCard()
	{
		cardPullProgress++;
		return inPlayDeck[(cardPullProgress - 1)];
	}

	public static void PlayGame()
	{
		int dealerCard = DrawCard();
		int dealerHiddenCard = DrawCard();
		Console.WriteLine($"The dealer drew a {dealerCard} and a hidden card.");

		int playerCard1 = DrawCard();
		int playerCard2 = DrawCard();
		Console.WriteLine($"You drew a {playerCard1} and a {playerCard2}.");
		handValue = (playerCard1 + playerCard2);
		Console.WriteLine($"Your hand value is now {handValue}.");

		//PlayerTurn();
	}

	public static void PlayerTurn()
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
			string userInput = Console.ReadLine();
			if (userInput == "H" || userInput == "Hit")
			{
				PlayerHit();
			}
			else if (userInput == "S" || userInput == "Stand")
			{
				Console.WriteLine($"Your final hand value is {handValue}.");
				DealerTurn();
			}
            else
            {
				Console.WriteLine("Oops! You entered an incorrect input. Please try again!");
				Thread.Sleep(1000);
				Console.Clear();
				PlayerTurn();
            }
		}
	}

	public static void PlayerHit()
	{
		int newCard = DrawCard();
		Console.WriteLine($"You drew a {newCard}!");
		handValue = handValue + newCard;
		PlayerTurn();
	}
}
