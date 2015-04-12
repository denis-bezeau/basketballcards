using UnityEngine;
using System.Collections;

/// <summary>
/// Basketball card game.
/// </summary>
public class BasketballCardGame 
{
	private User[] _users;
	public User[] Users
	{
		get { return _users; }
	}
	 
	private int[] _scores;
	public int[] Scores
	{
		get { return _scores; }
	}

	private int _winScore;
	public int WinScore
	{
		get { return _winScore; }
	}

	// Default ctor, create a Basketball Card Game, set the users and the scores.
	public BasketballCardGame(User[] users, int winScore)
	{
		_users = users;
		_scores = new int[users.Length];
		_winScore = WinScore;

		// Initialize the scores to 0.
		for(int i = 0; i < _scores.Length; i++)
		{
			_scores[i] = 0;
		}
	}
}
