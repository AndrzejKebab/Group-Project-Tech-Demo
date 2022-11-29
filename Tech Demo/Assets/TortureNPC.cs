using PatataStudio.DialogueSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TortureNPC : MonoBehaviour
{
	[SerializeField] private Color defaultColor = Color.white;
	[SerializeField] private Color firstColor = Color.red;
	[SerializeField] private Color secondColor = Color.green;
	[SerializeField] private Color thirdColor = Color.black;

	private SpriteRenderer spriteRenderer;


	private void Start()
	{
		spriteRenderer = GetComponent<SpriteRenderer>();
	}

	private void Update()
	{
		string somethingName = ((Ink.Runtime.StringValue) DialogueManager.instance.GetVariableState("something_name")).value;

		switch (somethingName)
		{
			case "":
				spriteRenderer.color = defaultColor;
				break;
			case "CockAndBalls":
				spriteRenderer.color = firstColor;
				break;
			case "Kartofel":
				spriteRenderer.color = secondColor;
				break;
			case "AnimeTiddies":
				spriteRenderer.color = thirdColor;
				break;
			default:
				Debug.LogWarning("Name not handled by switch statement: " + somethingName);
				break;
		}
	}
}
