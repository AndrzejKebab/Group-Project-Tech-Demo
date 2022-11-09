using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;
using TMPro;
using UnityEngine.UI;
using System;

public class NoteBook : MonoBehaviour
{
	[Header("Note UI")]
	[SerializeField] private GameObject notePage;
	[SerializeField] private TextMeshProUGUI notePageText;

	private Story currentNote;

	public void OnNoteClick(TextAsset inkJSON)
	{
		currentNote = new Story(inkJSON.text);
		notePage.SetActive(true);

		ContinueNote();
	}

	private void ContinueNote()
	{
		if (currentNote.canContinue)
		{
			notePageText.text = currentNote.Continue();
		}
	}
}
