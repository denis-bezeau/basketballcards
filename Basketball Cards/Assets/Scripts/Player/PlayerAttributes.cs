using System.Xml;
using System.Xml.Serialization;

/// <summary>
/// Holds the numerical values describing the players abilities
/// </summary>
public class PlayerAttributes
{
	public int Offence = 0;
	public int Defence = 1;

	public PlayerAttributes()
	{

	}

	public PlayerAttributes (int off, int def)
	{
		Offence = off;
		Defence = def;
	}
}
