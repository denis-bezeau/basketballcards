
using UnityEngine;
using System;

/// <summary>
/// Controls the match's movement between states.
/// </summary>
public class MatchStateManager : Singleton<MatchStateManager>
{
	/// <summary>
	/// Current state of the match.
	/// </summary>
	/// <remarks>Do not assign directly, use TransitionToState()</remarks>
	private MatchState currentState = null;
	public MatchState CurrentState {
		get{ return currentState;}
	}

	private void Awake ()
	{
		CTEventManager.AddListener<GameEvents.StateComplete> (OnStateComplete);
	}

	private void Start ()
	{
		TransitionToState (new InitialState ());
	}

	private void Update()
	{
		if(GameMonitor.Instance.Game != null)
		{
			if (currentState is InitialState)
			{
				if(GameMonitor.Instance.Game.IsInitialized)
				{
					currentState.StateComplete();
				}
			}
			else if (currentState is OffenceState)
			{

			}
			else if (currentState is DefenceState)
			{

			}
			else if (currentState is ResolveState)
			{

			}
			else if (currentState is PossessionChangeState)
			{

			}
		}
	}

	/// <summary>
	/// End the current match state and begin a new one.
	/// </summary>
	/// <param name="newState">The new state to enter</param>
	private void TransitionToState (MatchState newState)
	{
		if (newState == null)
		{
			Debug.LogError ("We don't want to go to null state, so no transition!");
			return;
		}

		if (currentState != null)
		{
			currentState.End ();
		}

		currentState = newState;
		currentState.Begin ();
	}

	private void OnStateComplete (GameEvents.StateComplete eventInfo)
	{
		TransitionToState (FindNextState ());
	}

	/// <summary>
	/// Decide what state should happen next given current game state and information
	/// </summary>
	/// <returns>The next state</returns>
	private MatchState FindNextState ()
	{
		// TODO: Probably not the best, but will leave for now until we have a better
		//       understanding of what we want this to be capable of.
		if (currentState is InitialState)
		{
			return new OffenceState ();
		}
		else if (currentState is OffenceState)
		{
			return new DefenceState ();
		}
		else if (currentState is DefenceState)
		{
			return new ResolveState ();
		}
		else if (currentState is ResolveState)
		{
			// TODO: We only want to go to possession change if the ball
			//       changed teams after resolution. Always go for now.
			return new PossessionChangeState ();
		}
		else if (currentState is PossessionChangeState)
		{
			return new OffenceState ();
		}
		return null;
	}
}