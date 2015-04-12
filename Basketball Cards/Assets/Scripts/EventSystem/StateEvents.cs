// File for events pertaining to the MatchState system
using System;

namespace GameEvents
{
	public class StateComplete : CTEvent
	{
		public Type StateType;
	}

	public class PlayAction : CTEvent
	{
		public ePlayType PlayType;
		public int PointValue;
	}
}

