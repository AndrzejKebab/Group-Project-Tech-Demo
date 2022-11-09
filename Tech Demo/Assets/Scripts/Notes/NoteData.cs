using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NoteData : MonoBehaviour
{
	[SerializeField] private Image backgroundImage = null;
	[SerializeField] private TextMeshProUGUI label = null;

	private Note note = null;
	private RectTransform rect = null;
	public RectTransform Rect
	{
		get
		{
			if(rect == null)
			{
				rect = GetComponent<RectTransform>();
				if(rect == null) { rect = gameObject.AddComponent<RectTransform>();}
			}
			return rect;
		}
	}

	public void UpdateInfo(Note note, Color color)
	{
		this.note = note;
		label.text = note.Label;
		backgroundImage.color = color;
	}

	public void Display()
	{
		GameObject.Find("NotesSystem").GetComponent<NoteSystem>().Display(note);
	}
}
