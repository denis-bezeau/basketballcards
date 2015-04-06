
public class PlayerCard : Card
{
	public string FirstName {
		get;
		private set;
	}

	public string LastName {
		get;
		private set;
	}

	public string FullName {
		get {
			return FirstName + " " + LastName;
		}
	}

	public PlayerAttributes Attributes {
		get;
		private set;
	}

	public PlayerCard (string firstName, string lastName, PlayerAttributes attributes)
	{
		FirstName = firstName;
		LastName = lastName;
		Attributes = attributes;
	}
}