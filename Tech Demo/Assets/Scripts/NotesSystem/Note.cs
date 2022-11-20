using UnityEngine;

namespace PatataStudio.NoteBookSystem
{
	[CreateAssetMenu(fileName = "new Note", menuName = "NoteBook System/New Note")]
	public class Note : ScriptableObject
	{
		[SerializeField] private string label = string.Empty;
		public string Label { get { return label; } }

		[SerializeField] Page[] pages = new Page[0];
		public Page[] Pages { get { return pages; } }
	}
}