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
}
}