using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DeckTestScript : MonoBehaviour
{
	void Start () 
	{
		//create a new deck
		CardDeck newDeck = new CardDeck();

		//print the cards in the draw pile
		newDeck.Print(CardDeck.DeckType.DrawPile);

		//shuffle it
		newDeck.Shuffle(new List<CardDeck.DeckType>() { CardDeck.DeckType.All }, false);

		//print the cards in the draw pile now that they're shuffled
		newDeck.Print(CardDeck.DeckType.DrawPile);

		//shuffle it again, this time returning all the cards to the drawpile
		newDeck.Shuffle(new List<CardDeck.DeckType>() { CardDeck.DeckType.All }, true);

		//print the draw pile again
		newDeck.Print(CardDeck.DeckType.DrawPile);
	}
}
