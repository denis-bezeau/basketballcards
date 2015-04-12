using UnityEngine;
using System.Collections;

/// <summary>
/// Basic User class, should contain identification and deck information.
/// </summary>
using System.Collections.Generic;


public class User 
{
	private int _Id;
	public int Id
	{
		get { return Id; }
	}

	private string _userName;
	public string UserName
	{
		get { return _userName; }
	}

	private CardDeck _deck;
	public CardDeck Deck
	{
		get { return _deck; }
	}

	public List<Card> _hand;
	public List<Card> Hand
	{
		get { return _hand; }
	}

	public User(int id, string userName, CardDeck deck)
	{
		_Id = id;
		_userName = userName;
		_deck = deck;

		_hand = new List<Card>();
	}
}
