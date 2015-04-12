using UnityEngine;
using System.Collections;
using System.Xml;
using System.Xml.Serialization;

public class Card 
{
	public string Title;

	public string Description;

	public int CardValue;

	public Card()
	{
	}

	public string ToString()
	{
		return Title + ": " + Description;
	}

	public void Play()
	{
		if(MatchStateManager.Instance.CurrentState is OffenceState)
		{
			CTEventManager.FireEvent (new GameEvents.PlayAction () { PlayType = ePlayType.Offensive, PointValue = CardValue });
		}
		else if(MatchStateManager.Instance.CurrentState is DefenceState)
		{
			CTEventManager.FireEvent (new GameEvents.PlayAction () { PlayType = ePlayType.Defensive, PointValue = CardValue });
		}
	}
}