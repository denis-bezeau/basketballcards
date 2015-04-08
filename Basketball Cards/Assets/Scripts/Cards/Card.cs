using UnityEngine;
using System.Collections;
using System.Xml;
using System.Xml.Serialization;

public class Card 
{
	public string Title;

	public string Description;

	public Card()
	{

	}

	public string ToString()
	{
		return Title + ": " + Description;
	}
}