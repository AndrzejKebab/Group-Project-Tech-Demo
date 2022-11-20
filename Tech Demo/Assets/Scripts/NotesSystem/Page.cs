using UnityEngine;

namespace PatataStudio.NoteBookSystem
{
	public enum PageType
	{
		Text = 0,
		Texture = 1,
	}

	[CreateAssetMenu(fileName = "new Page", menuName = "NoteBook System/New Page")]
	public class Page : ScriptableObject
	{
		[SerializeField] private PageType type = PageType.Text;
		public PageType Type { get { return type; } }

		[TextArea(8, 16)]
		[SerializeField] private string text = string.Empty;
		public string Text { get { return text; } }

		[SerializeField] private Sprite texture = null;
		public Sprite Texture { get { return texture; } }

		[SerializeField] private bool useSubscript = true;
		public bool UseSubscript { get { return useSubscript; } }

		[SerializeField] private bool displayLines = false;
		public bool DisplayLines { get { return displayLines; } }

		#region Audio
		[SerializeField] private AudioClip narration = null;
		public AudioClip Narration { get { return narration; } }

		[SerializeField] private bool narration_PlayOnce = true;
		public bool Narration_PlayOnce { get { return narration_PlayOnce; } }

		[SerializeField] private bool narrationPlayed = false;
		public bool NarrationPlayed { get { return narrationPlayed; } set { narrationPlayed = value; } }
		#endregion
	}
}
