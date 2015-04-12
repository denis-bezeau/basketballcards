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
	
	// Monitor Vars
	private System.Random randomGenerator = new System.Random();
	private BasketballCardGame _game;

	protected GameMonitor () {}

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

			users[i] = new User(i, "Player " + i, newDeck);
		}
		_game = new BasketballCardGame(users, DEBUG_WIN_SCORE);
	}

	public void StartGame()
	{
		if (_game != null)
		{
			// Draw each users starting hand.
			for(int i = 0; i < _game.Users.Length; i++)
			{
				for(int j = 0; j < USER_HAND_SIZE; j++)
				{
					_game.Users[i].Hand.Add (_game.Users[i].Deck.DrawPile.DrawCard());
				}
			}

			// Flip a coin to see who goes first.
			int flip = randomGenerator.Next(2);

			// Start the state for turn one?
		}
	}
}
