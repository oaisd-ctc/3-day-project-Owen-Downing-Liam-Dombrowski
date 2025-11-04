using System.Net;
using System.Security.AccessControl;
using Cards;

public class Program
{
	public static void Main(string[] args)
	{
		Console.Clear();
		Console.WriteLine("Hello gamblers!");
		ViewRules();
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
			Console.WriteLine($"Dealer reveals the hidden card, which is a {dealerHiddenCard}. The dealer now has {dealerHandValue}.");
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
				/*int dealerWinCheck = CheckForDealerWin();
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
                }*/
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
		//dealerHandValue = dealerHandValue + dealerCard;
		if (dealerHandValue < 17)
		{
			dealerHandValue = dealerHandValue + dealerCard;
			Console.WriteLine($"Dealer has pulled a {dealerCard}. The dealer is now at {dealerHandValue}.");
			Thread.Sleep(500);
			DealerTurn();
		}
		else if ((dealerHandValue >= 17) && (dealerHandValue < 21))
		{
			Console.WriteLine($"The dealer is now standing at {dealerHandValue}.");
			CheckForDealerWin();
		}
		else if (dealerHandValue == 21)
		{
			Console.WriteLine($"The dealer has reached 21! That's a Blackjack for the dealer!");
			CheckForDealerWin();
		}
		else
		{
			Console.WriteLine($"The dealer busts with a hand of {dealerHandValue}. You win!");
			//Player gets credited here.
		}
	}

	public static void PlayerHit()
	{
		int newCard = DrawCard();
		Console.WriteLine($"You drew a {newCard}!");
		handValue = handValue + newCard;
		PlayerTurn();
	}

	public static void CheckForDealerWin()
	{
		if (handValue > dealerHandValue)
		{
			Console.WriteLine($"The dealer has a final hand value of {dealerHandValue}, while you have a final hand value of {handValue}. You win!");
			//Console.WriteLine($"You have been credited {roundEndingCredits}");
			//Need to implement credit system!
		}
		else if (handValue < dealerHandValue)
		{
			Console.WriteLine($"The dealer has a final hand value of {dealerHandValue}, while you have a final hand value of {handValue}. Dealer wins!");
			//Console.WriteLine("You have lost 100% of your original bet.");
		}
		else
		{
			Console.WriteLine($"The dealer has a final hand value of {dealerHandValue}, while you have a final hand value of {handValue}. The round is a stalemate.");
			//Console.WriteLine("You have been credited 100% of your original bet.");
		}
		RandomizePlayDeck();
		Console.WriteLine("A new game will start in 5 seconds.");
		Thread.Sleep(5000);
		PlayGame();
	}
	
	public static void ViewRules()
	{
		Console.WriteLine("Would you like to read the rules prior to starting this session? (Y / N)");
		string userRulesIntent = Console.ReadLine()!;
		userRulesIntent = userRulesIntent.ToLower();
		if (userRulesIntent == "y")
		{
			Console.Clear();
			Console.WriteLine("There is one shoe, which contains one deck of cards EXCLUDING suits (13 cards total).");
			Console.WriteLine("The shoe is randomized every round.");
			Console.WriteLine("\nDealer Rules\n\nDealer will take two cards at the start of a round, showing one to the player and keeping the other hidden until the player has finished making their moves.");
			Console.WriteLine("Dealer MUST hit on 16 or lower.");
			Console.WriteLine("Dealer will stand on soft 17 (Ace + 6).");
			Console.WriteLine("\nPlayer Rules\n\nPlayers will be dealt two cards at the start of the round.");
			Console.WriteLine("Players will have the option to hit or stand. They can continue to hit as many times as they want until busting. Or, they can choose to stand.\n*Players are not required to hit.*");
			Console.WriteLine("Players will have the option to double down, placing a new bet equal to 100% of their original bet. After doubling down, they will NOT be able to hit anymore, and the dealer will pull cards until they reach a card to stand on or they bust.");
			Console.WriteLine("Players will have the option to split their hand. Splitting the hand will move gameplay to a new function, splitting their cards to two different decks. They will receive a new deck, automatically betting 100% of their original bet.");
			Console.WriteLine("Payout\n\nBlackjack pays 3:2\nInsurance pays 2:1");
			Console.WriteLine("\nPress enter when you're ready to continue to the game.");
			Console.Read();
			Console.Clear();
		}
		else if (userRulesIntent == "n")
		{
			Console.Clear();
		}
        else
        {
			Console.WriteLine("You have entered an incorrect input. Please enter a correct input value.");
			Thread.Sleep(500);
			Console.Clear();
			ViewRules();
        }
    }
	//This dealer win method is deprecated and is not going to be used. Left here for now in case we need to come back to the logic of it.
	/*public static int CheckForDealerWin()
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
    }*/
}
