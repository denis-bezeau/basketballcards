using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

public class CardPile
{
	/// <summary>
	/// List of cards in this pile
	/// </summary>
	[XmlArray("cards")]
	[XmlArrayItem("Card", typeof(Card))]
	[XmlArrayItem("PlayerCard", typeof(PlayerCard))]
	public List<Card> cards;

	public CardPile()
	{
		//instantiate cardList
		cards = new List<Card>();
	}
	
	/// <summary>
	/// Shuffle function that i stole off of stackoverflow, it makes sense, there might be more efficient ones out there
	/// </summary>
	public void Shuffle()
	{
		//create a random number generator
		System.Random rng = new System.Random();
		
		//iterate through the cards backwards
		for (int i = cards.Count - 1; i > 0; i--)
		{
			// Swap element "i" with a random earlier element
			int swapIndex = rng.Next(i + 1);
			Card temporaryCard = cards[i];
			cards[i] = cards[swapIndex];
			cards[swapIndex] = temporaryCard;
		}
	}
	
	/// <summary>
	/// returns a list of all cards in this pile
	/// </summary>
	/// <returns>list of all cards in this pile</returns>
	public List<Card> GetCardList()
	{
		return cards;
	}
	
	/// <summary>
	/// Gets the last card in the card list then removes it from the list
	/// </summary>
	/// <returns>if the card list is empty then this returns null, otherwise it returns the last card in the list</returns>
	public Card DrawCard()
	{
		Card returnCard = null;
		if (cards.Count <= 0)
		{
			Debug.LogWarning("CardPile is empty, you cannot draw from this pile.");
		}
		else
		{
			returnCard = cards[(cards.Count - 1)];
			cards.RemoveAt((cards.Count - 1));
		}
	
		return returnCard;
	}
	
	/// <summary>
	/// Removes all cards from this deck
	/// </summary>
	public void Clear()
	{
		cards.Clear();
	}
	
	/// <summary>
	/// prints a list of all the cards in this pile
	/// </summary>
	public string ToString()
	{
		string returnValue = string.Empty;
	
		for (int i = 0; i < cards.Count; ++i)
		{
			returnValue += (i + ". " + cards[i].ToString() + "\n");
		}
	
		return returnValue;
	}
	
	/// <summary>
	/// adds a card to the card list
	/// </summary>
	/// <param name="newCard">the card to add</param>
	public void AddCard(Card newCard)
	{
		cards.Add(newCard);
	}
	
	/// <summary>
	/// find out if the specified card exists in this card pile
	/// </summary>
	/// <param name="possibleCard"></param>
	/// <returns>
	/// true: card list contains a copy of that card
	/// false: card list does not contain a copy of that card
	/// </returns>
	public bool Contains(Card possibleCard)
	{
		//return true if the card list contains this card
		return cards.Contains(possibleCard);
	}

	public void Save(string path)
	{
		var serializer = new XmlSerializer(typeof(CardPile));
		using (var stream = new FileStream(path, FileMode.Create))
		{
			serializer.Serialize(stream, this);
		}
	}

	public void Load(string path)
	{
		var serializer = new XmlSerializer(typeof(CardPile));
		using (var stream = new FileStream(path, FileMode.Open))
		{
			CardPile cardpile = serializer.Deserialize(stream) as CardPile;
			cards.Clear();
			cards = cardpile.cards;
		}
	}
}
