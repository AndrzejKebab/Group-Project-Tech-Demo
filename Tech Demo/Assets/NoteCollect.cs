using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteCollect : MonoBehaviour
{
	[SerializeField] private Note note = null;

	[SerializeField] private bool autoDisplay = false;
	[SerializeField] private bool add = true;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			if (autoDisplay)
			{
				GameObject.Find("NotesSystem").GetComponent<NoteSystem>().Display(note);
			}

			if (add)
			{
				GameObject.Find("NotesSystem").GetComponent<NoteSystem>().AddNote(note.Label, note);
			}

			Destroy(this.gameObject);
		}
	}
}
