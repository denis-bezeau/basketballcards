using UnityEngine;
using System;
using System.Collections;
using System.IO;
using System.Collections.Generic;

/// <summary>
/// Game monitor.
/// </summary>
public class GameMonitor : Singleton<GameMonitor> 
{
	// Game Constants
	private static readonly int NUM_USERS = 2;
	private static readonly int USER_HAND_SIZE = 5;
	private static readonly int DEBUG_WIN_SCORE = 20;

	private Queue _cardsInPlay;
	
	// Monitor Vars
	private System.Random randomGenerator = new System.Random();

	private BasketballCardGame _game;
	public BasketballCardGame Game
	{
		get { return _game; }
	}

	private User _currentUser;

	private BasketballPlay _currentPlay;

	protected GameMonitor () {}

	private void Awake()
	{
		CTEventManager.AddListener<GameEvents.PlayAction> (OnPlayAction);
	}

	private void Start()
	{
		InitializeNewGame();
	}

	private void OnDestroy()  	
	{
		CTEventManager.RemoveListener<GameEvents.PlayAction>(OnPlayAction);
		base.OnDestroy();
	}

	public void InitializeNewGame()
	{
		User[] users = new User[NUM_USERS];

		for(int i = 0; i < NUM_USERS; i++)
		{
			string path = Path.Combine(Application.persistentDataPath, "testdeck_player" + i + ".xml");
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

			for(int k = 0; k < newDeck.DrawPile.cards.Count; k++)
			{
				newDeck.DrawPile.cards[k].CardValue = randomGenerator.Next(1, 20);
			}

			users[i] = new User(i, "Player " + i, newDeck);
		}
		_game = new BasketballCardGame(users, DEBUG_WIN_SCORE);

		// Flip a coin to see who goes first.
		int flip = randomGenerator.Next(2);
		
		_currentUser = _game.Users[flip];
		
		// Game is initialized;
		_game.IsInitialized = true;

	}

	public void StartGame()
	{
		if (_game != null)
		{
			Debug.Log ("Starting new game!");
			// Draw each users starting hand.
			for(int i = 0; i < _game.Users.Length; i++)
			{
				for(int j = 0; j < USER_HAND_SIZE; j++)
				{
					_game.Users[i].Hand.Add (_game.Users[i].Deck.DrawPile.DrawCard());
				}

				Debug.Log ("------------------ PRINTING STARTING HAND FOR USER: " + i + " ------------------");
				foreach(Card c in _game.Users[i].Hand)
				{
					Debug.Log (c.Title + " " + c.Description + " " + c.CardValue);
				}
				Debug.Log ("------------------ END PRINTING STARTING HAND FOR USER: " + i + " ------------------");
			}
			BeginTurn (_currentUser);
		}
	}

	// Start a turn.
	public void BeginTurn(User user)
	{
		_currentUser = user;
		_currentUser.Deck.DrawPile.DrawCard();
		_cardsInPlay = new Queue();
		StopAllCoroutines();
		StartCoroutine(MonitorTurn());
	}

	private IEnumerator MonitorTurn()
	{
		yield return StartCoroutine(ExecuteTurn());
		_cardsInPlay = null;
	}

	private IEnumerator ExecuteTurn()
	{
		// Does the user have cards in hand?
		while(_currentUser.Hand.Count > 0)
		{
			bool hasPlayableCard = false;
			for(int i = 0; i < _currentUser.Hand.Count; i++)
			{
				if (MatchStateManager.Instance.CurrentState.PlayableCardTypes.Contains(_currentUser.Hand[i].GetType()))
				{
					hasPlayableCard = true;
				}
			}

			// If the user has no playable card, execit the turn.
			if(!hasPlayableCard)
			{
				yield break;
			}

			// Does the user have cards to resolve?
			if(_cardsInPlay.Count > 0)
			{
				Card playedCard = (Card)_cardsInPlay.Dequeue();
				playedCard.Play();
			}
			yield return null;
		}
		yield return null;
	}

	public void AddPlayedCard(Card card)
	{
		if(_cardsInPlay != null)
		{
			_cardsInPlay.Enqueue(card);
		}
	}

	private void OnPlayAction(GameEvents.PlayAction eventInfo)
	{
		if(eventInfo.PlayType == ePlayType.Offensive)
		{
			_currentPlay.OffensiveValue = eventInfo.PointValue;
		}
		else if (eventInfo.PlayType == ePlayType.Defensive)
		{
			_currentPlay.DefensiveValue = eventInfo.PointValue;
		}
	}
}

public enum ePlayType
{
	Offensive = 0,
	Defensive
}
