
using UnityEngine;
using System.Collections.Generic;
using System;

public class MatchState
{
	private float stateDuration = 0f;
	private bool offenceCanDraw = false;
	private bool defenceCanDraw = false;
	private bool offenceCanPlay = false;
	private bool defenceCanPlay = false;
	private List<Type> playableCardTypes = new List<Type> ();

	/// <summary>
	/// Call when moving to this state.
	/// </summary>
	public virtual void Begin ()
	{
		// Establish things necessary to detect the end of the state
		Debug.Log ("Begin " + this.GetType () + " state");
	}

	/// <summary>
	/// Function to call when the conditions to complete the state
	/// have been achieved. Call base as final action in overrides.
	/// </summary>
	public virtual void StateComplete ()
	{
		CTEventManager.FireEvent (new GameEvents.StateComplete () {StateType = this.GetType ()});
	}

	/// <summary>
	/// Call when leaving this state
	/// </summary>
	public virtual void End ()
	{
		// Clean it all up
		Debug.Log ("End " + this.GetType () + " state");
	}

	public bool HasDuration {
		get { return stateDuration > 0f;}
	}
}