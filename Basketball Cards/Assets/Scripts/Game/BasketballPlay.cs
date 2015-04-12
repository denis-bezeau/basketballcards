using UnityEngine;
using System.Collections;

public class BasketballPlay 
{
	private int _offensiveValue;
	public int OffensiveValue
	{
		get { return _offensiveValue; }
		set { _offensiveValue = value; }
	}

	private int _defensiveValue;
	public int DefensiveValue
	{
		get { return _defensiveValue; }
		set { _defensiveValue = value; }
	}
	
	public BasketballPlay()
	{
		_offensiveValue = 0;
		_defensiveValue = 0;
	}
}