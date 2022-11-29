using PatataStudio.DataPersitence;
using PatataStudio.NoteBookSystem;
using UnityEngine;

public class NoteCollect : MonoBehaviour , IDataPersistence
{
	[SerializeField] private Note note = null;

	[SerializeField] private bool autoDisplay = false;
	[SerializeField] private bool add = true;

	private bool isCollected = false;

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
				AddThisNote();
				isCollected = true;
			}

			Destroy(this.gameObject);
		}
	}

	private void AddThisNote()
	{
		GameObject.Find("NotesSystem").GetComponent<NoteSystem>().AddNote(note.Label, note);
	}

	public void LoadData(GameData data)
	{
		data.CollectedNotes.TryGetValue(note.name, out isCollected);
		if (isCollected == true)
		{
			AddThisNote();
			Destroy(this.gameObject);
		}
	}

	public void SaveData(GameData data)
	{
		if (data.CollectedNotes.ContainsKey(note.name))
		{
			data.CollectedNotes.Remove(note.name);
		}
		data.CollectedNotes.Add(note.name, isCollected);
	}

}
