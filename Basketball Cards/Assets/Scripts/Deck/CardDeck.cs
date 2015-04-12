using System.Collections.Generic;

public class CardDeck
{
	public enum DeckType
	{
		All,
		DrawPile,
		DiscardPile,
		ExilePile,
	}
	/// <summary>
	/// List of All cards
	/// </summary>
	public CardPile AllCards;

	/// <summary>
	/// List of unplayed cards in a match
	/// </summary>
	public CardPile DrawPile;

	/// <summary>
	/// Cards played and discarded in a match
	/// </summary>
	public CardPile DiscardPile;

	/// <summary>
	/// Cards played and Exiled in a match (Exiled cards can not be reshuffled back into your deck for any reason)
	/// </summary>
	public CardPile ExilePile;

	public CardDeck ()
	{
		//instantiate card piles
		AllCards = new CardPile();
		DrawPile = new CardPile();
		DiscardPile = new CardPile();
		ExilePile = new CardPile();
	}

	public bool LegalCheckDeck (DeckRules testRules)
	{
		// TODO: Check deck properties against the given rule set
		return true;
	}

	/// <summary>
	/// Testing function used to generate card data for testing
	/// </summary>
	public void GenerateTestCards()
	{
		//generate 30 cards for the draw pile
		for (int i = 0; i < 30; ++i)
		{
			Card newCard = new Card();
			newCard.Title = "drawpile card " + i.ToString();
			newCard.Description = "drawpile description " + i.ToString();
			DrawPile.AddCard(newCard);
			AllCards.AddCard(newCard);
		}

		//generate 10 cards for the discard pile
		for (int i = 0; i < 10; ++i)
		{
			PlayerCard newCard = new PlayerCard();
			newCard.Title = "discarded card " + i.ToString();
			newCard.Description = "discarded description " + i.ToString();
			newCard.FirstName = "FirstName" + i.ToString();
			newCard.LastName = "LastName" + i.ToString();
			newCard.Attributes = new PlayerAttributes(i, i);
			DiscardPile.AddCard(newCard);
			AllCards.AddCard(newCard);
		}

		//generate 5 cards for the exile pile
		for (int i = 0; i < 5; ++i)
		{
			Card newCard = new Card();
			newCard.Title = "exiled card " + i.ToString();
			newCard.Description = "exiled description " + i.ToString();
			ExilePile.AddCard(newCard);
			AllCards.AddCard(newCard);
		}
	}

	/// <summary>
	/// shuffles all piles specified in the List, if the bool is true all shuffled cards will be added to the drawpile,
	/// otherwise they will remain in their starting pile
	/// </summary>
	/// <param name="DeckList">list of all the decks that need to be shuffled</param>
	/// <param name="returnShuffledCardsToDrawPile">
	/// true: cards will be returned to the draw pile after shuffling
	/// false: cards will remain in their current deck after shuffling
	/// </param>
	public void Shuffle(List<DeckType> DeckList, bool returnShuffledCardsToDrawPile)
	{
		for (int i = 0; i < DeckList.Count; ++i)
		{
			switch(DeckList[i])
			{
				case DeckType.All:
					{
						//recursively shuffle all the piles
						Shuffle(new List<DeckType>() { DeckType.DrawPile }, returnShuffledCardsToDrawPile);
						Shuffle(new List<DeckType>() { DeckType.DiscardPile }, returnShuffledCardsToDrawPile);
						Shuffle(new List<DeckType>() { DeckType.ExilePile }, returnShuffledCardsToDrawPile);
						break;
					}
				case DeckType.DrawPile:
					{
						//just shuffle the draw pile
						DrawPile.Shuffle();
						break;
					}
				case DeckType.DiscardPile:
					{
						//if shuffling into the draw pile
						if (returnShuffledCardsToDrawPile == true)
						{
							//get the list of cards
							List<Card> cardPile = DiscardPile.GetCardList();

							//iterate through all the cards
							for (int j = 0; j < cardPile.Count; ++j)
							{
								//add this card to the draw pile
								DrawPile.AddCard(cardPile[j]);
							}
							DrawPile.Shuffle();

							cardPile.Clear();
							DiscardPile.Clear();
						}
						else
						{
							//else just shuffle the discardpile
							DiscardPile.Shuffle();
						}
						break;
					}
				case DeckType.ExilePile:
					{
						//if shuffling into the draw pile
						if (returnShuffledCardsToDrawPile == true)
						{
							//get the list of cards
							List<Card> cardPile = ExilePile.GetCardList();
							
							//iterate through all the cards
							for (int j = 0; j < cardPile.Count; ++j)
							{
								//add this card to the draw pile
								DrawPile.AddCard(cardPile[j]);
							}
							DrawPile.Shuffle();

							cardPile.Clear();
							ExilePile.Clear();
						}
						else
						{
							//else just shuffle the exile pile
							ExilePile.Shuffle();
						}
						break;
					}
			}
		}
	}

	/// <summary>
	/// prints the card content of the specified deck
	/// </summary>
	/// <param name="deckType"> which deck to print the contents of</param>
	public void Print(DeckType deckType = DeckType.All)
	{
		switch (deckType)
		{
			case DeckType.All:
				{
					UnityEngine.Debug.Log("----------------------\nPrinting AllCards\n----------------------\n");
					UnityEngine.Debug.Log(AllCards.ToString());
					break;
				}
			case DeckType.DrawPile:
				{
					UnityEngine.Debug.Log("----------------------\nPrinting DrawPile\n----------------------\n");
					UnityEngine.Debug.Log(DrawPile.ToString());
					break;
				}
			case DeckType.DiscardPile:
				{
					UnityEngine.Debug.Log("----------------------\nPrinting DiscardPile\n----------------------\n");
					UnityEngine.Debug.Log(DiscardPile.ToString());
					break;
				}
			case DeckType.ExilePile:
				{
					UnityEngine.Debug.Log("----------------------\nPrinting ExilePile\n----------------------\n");
					UnityEngine.Debug.Log(ExilePile.ToString());
					break;
				}
		}
	}

	public void Save(string path)
	{
		DrawPile.Save(path);
	}

	public void Load(string path)
	{
		DrawPile.Load(path);
	}
}