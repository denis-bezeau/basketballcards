using System.Collections.Generic;

public class CardDeck
{
	/// <summary>
	/// All cards used by a deck
	/// </summary>
	private List<Card> AllCards;

	/// <summary>
	/// List of unplayed cards in a match
	/// </summary>
	private List<Card> DrawPile;

	/// <summary>
	/// Cards played and discarded in a match
	/// </summary>
	private List<Card> DiscardPile;


	public CardDeck ()
	{
		AllCards = new List<Card> ();
		DrawPile = new List<Card> ();
		DiscardPile = new List<Card> ();
	}

	public bool LegalCheckDeck (DeckRules testRules)
	{
		// TODO: Check deck properties against the given rule set
		return true;
	}
	
}