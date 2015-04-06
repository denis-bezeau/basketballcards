
public class DeckRules
{
	/// <summary>
	/// Number of cards allowed in a deck
	/// </summary>
	public int CardCount = 60;

	/// <summary>
	/// Number of player cards allowed in a deck
	/// </summary>
	public int PlayerCount = 30;

	public DeckRules ()
	{
	}
	
	public DeckRules (int numCards, int numPlayers)
	{
		CardCount = numCards;
		PlayerCount = numPlayers;
	}
	
}
