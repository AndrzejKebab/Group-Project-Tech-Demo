using PatataStudio.DialogueSystem;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIobjects : MonoBehaviour
{
	[SerializeField] public TextMeshProUGUI circlesTxt;

	// Update is called once per frame
	void Update()
	{
		circlesTxt.text = "Circles Picked: " + DialogueManager.instance.GetVariableState("circlesPicked") + " / 6";
	}
}
