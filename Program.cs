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
		dealerHandValue = 0;
		dealerHiddenCard = 0;
    }
	public static int handValue;
	public static int dealerHandValue;
	public static int dealerHiddenCard;

	public static int DrawCard()
	{
		cardPullProgress++;
		return inPlayDeck[(cardPullProgress - 1)];
	}

	public static void PlayGame()
	{
		int dealerCard = DrawCard();
		dealerHiddenCard = DrawCard();
		dealerHandValue = dealerCard + dealerHiddenCard;
		Console.WriteLine($"The dealer drew a {dealerCard} and a hidden card.");

		int playerCard1 = DrawCard();
		int playerCard2 = DrawCard();
		Console.WriteLine($"You drew a {playerCard1} and a {playerCard2}.");
		handValue = (playerCard1 + playerCard2);
		Console.WriteLine($"Your hand value is now {handValue}.");

		PlayerTurn();
	}

	public static void PlayerTurn()
	{
		if (handValue > 21)
		{
			Console.WriteLine($"You busted with {handValue}! The dealer wins!\nA new game will start in 5 seconds.");
			//Function to move to next game, not sure how we want to move it forward
			Thread.Sleep(5000);
			PlayGame();
		}
		else if (handValue == 21)
		{
			Console.WriteLine($"You got 21! Now its up to the dealer.");
			DealerTurn();
		}
		else
		{
			Console.WriteLine($"Your hand value is {handValue}. Would you like to hit or stand? (H / S)");
			string userInput = Console.ReadLine()!;
			if (userInput == "H" || userInput == "Hit")
			{
				PlayerHit();
			}
			else if (userInput == "S" || userInput == "Stand")
			{
				Console.WriteLine($"Your final hand value is {handValue}.");
				Console.WriteLine($"Dealer reveals the hidden card, which is a {dealerHiddenCard}. The dealer now has {dealerHandValue}.");
				int dealerWinCheck = CheckForDealerWin();
				if (dealerWinCheck == 2)
				{
					Console.WriteLine("The dealers hand is higher than yours. The dealer wins!\nA new game will start in 5 seconds.");
					Thread.Sleep(5000);
					PlayGame();
				}
				else if ((dealerWinCheck == 0) && !(dealerHandValue >= 17))
				{
					DealerTurn();
				}
				else if ((dealerWinCheck == 1) && !(dealerHandValue >= 17))
                {
					DealerTurn();
                }
                else
                {
					Console.WriteLine("The dealer has the same hand as you, the round is a stalemate. You bet has been returned to you.\nA new game will start in 5 seconds.");
					Thread.Sleep(5000);
					PlayGame();
                }
				DealerTurn();
			}
			else
			{
				Console.WriteLine("Oops! You entered an incorrect input. Please try again!");
				Thread.Sleep(500);
				Console.Clear();
				PlayerTurn();
			}
		}
	}
	
	public static void DealerTurn()
    {
		int dealerCard = DrawCard();
		dealerHandValue = dealerHandValue + dealerCard;
		if (dealerHandValue < 17)
		{
			Console.WriteLine($"Dealer has pulled a {dealerCard}. The dealer is now at {dealerHandValue}.");
			Thread.Sleep(500);
			DealerTurn();
		}
		else if ((dealerHandValue >= 17) && (dealerHandValue < 21))
		{
			Console.WriteLine($"Dealer has pulled a {dealerCard}. The dealer is now standing at {dealerHandValue}.");
		}
		else if (dealerHandValue == 21)
		{
			Console.WriteLine($"Dealer has pulled a {dealerCard}, and that's a Blackjack!");
		}
        else
        {
			Console.WriteLine($"Dealer has pulled a {dealerCard} and busts with a hand of {dealerHandValue}. You win!");
        }
    }

	public static void PlayerHit()
	{
		int newCard = DrawCard();
		Console.WriteLine($"You drew a {newCard}!");
		handValue = handValue + newCard;
		PlayerTurn();
	}

	public static int CheckForDealerWin()
    {
		if (handValue < dealerHandValue)
		{
			return 2;
		}
		else if (handValue > dealerHandValue)
		{
			return 0;
		}
        else
        {
			return 1;
        }
    }
}
