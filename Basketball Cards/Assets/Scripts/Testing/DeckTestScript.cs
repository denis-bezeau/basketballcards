using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class DeckTestScript : MonoBehaviour
{
	void Start () 
	{
		string path = Path.Combine(Application.persistentDataPath, "testdeck.xml");
		Debug.Log("path=" + path);

		//create a new deck
		CardDeck newDeck = new CardDeck();

		//print the cards in the draw pile
		newDeck.Print(CardDeck.DeckType.DrawPile);

		if (File.Exists(path) == true)
		{
			newDeck.Load(path);
		}
		else
		{
			newDeck.GenerateTestCards();
		}

		//shuffle it
		newDeck.Shuffle(new List<CardDeck.DeckType>() { CardDeck.DeckType.All }, false);

		//print the cards in the draw pile now that they're shuffled
		newDeck.Print(CardDeck.DeckType.DrawPile);

		//shuffle it again, this time returning all the cards to the drawpile
		newDeck.Shuffle(new List<CardDeck.DeckType>() { CardDeck.DeckType.All }, true);

		//print the draw pile again
		newDeck.Print(CardDeck.DeckType.DrawPile);


		newDeck.Save(path);
	}
}
