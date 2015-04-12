using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Basic User class, should contain identification and deck information.
/// </summary>
public class User 
{
	private int _Id;
	public int Id
	{
		get { return _Id; }
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

	public void PlayCard(Card card)
	{
		Debug.Log ("------------------ User: " + _Id + " is now attempting to play card: " + card.ToString());
		// Card is playable
		if (MatchStateManager.Instance.CurrentState.PlayableCardTypes.Contains(card.GetType()))
		{
			GameMonitor.Instance.AddPlayedCard(card);
		}
		// Card isn't playable.
		else
		{
			Debug.Log ("You cannot play this card.");
		}
	}
}
