using System.Xml;
using System.Xml.Serialization;

public class PlayerCard : Card
{
	public string FirstName 
	{
		get;
		set;
	}

	public string LastName 
	{
		get;
		set;
	}

	public string FullName 
	{
		get
		{
			return FirstName + " " + LastName;
		}
	}

	public PlayerAttributes Attributes
	{
		get;
		set;
	}

	public PlayerCard ()
	{

	}

	public PlayerCard(string firstName, string lastName, PlayerAttributes attributes)
	{
		FirstName = firstName;
		LastName = lastName;
		Attributes = attributes;
	}
}