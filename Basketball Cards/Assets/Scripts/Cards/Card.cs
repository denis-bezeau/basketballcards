using UnityEngine;
using System.Collections;

public class Card 
{
	protected string title;
	protected string description;

		public string Title
		{
			get { return title; }
			set { title = value; }
		}
		
		public string Description
		{
			get { return description; }
			set { description = value; }
		}
		
		public string ToString()
		{
			return Title + ": " + Description;
		}
}
