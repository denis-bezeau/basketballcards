using UnityEngine;
using System.Collections.Generic;

public class OffenceState : MatchState
{
	/// <summary>
	/// Call when moving to this state.
	/// </summary>
	public override void Begin ()
	{
		base.Begin();
		if (GameMonitor.Instance.Game != null && !GameMonitor.Instance.Game.Started)
		{
			GameMonitor.Instance.StartGame();
		}
	}
}
