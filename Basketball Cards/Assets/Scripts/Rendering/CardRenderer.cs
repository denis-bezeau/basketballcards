using UnityEngine;
using System.Collections;
using System;

/// <summary>
/// Card renderer.
/// </summary>
public class CardRenderer : MonoBehaviour 
{
	[SerializeField]
	private TextField[] textFields;

	[SerializeField]
	private SpriteRenderer cardSprite;

	public void Init()
	{

	}
}

[Serializable]
public class TextField
{
	[SerializeField]
	private eCardTextFieldType textFieldType;
	[SerializeField]
	private TextMesh textMesh;
}

public enum eCardTextFieldType
{
	Title = 0,
	Power,
	Defense,
	Description
}
