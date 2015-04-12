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

	private bool _isInitialized;
	public bool IsInitialized
	{
		get { return _isInitialized; }
		set { _isInitialized = value; }
	}

	private bool _started;
	public bool Started
	{
		get { return _started; }
		set { _started = value; }
	}

	// Default ctor, create a Basketball Card Game, set the users and the scores.
	public BasketballCardGame(User[] users, int winScore)
	{
		_isInitialized = false;
		_started = false;
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
