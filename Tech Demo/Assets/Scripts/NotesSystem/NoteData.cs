using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace PatataStudio.NoteBookSystem
{
	public class NoteData : MonoBehaviour
	{
		[SerializeField] private Image backgroundImage = null;
		[SerializeField] private TextMeshProUGUI label = null;
		//[SerializeField] private Image unreadDot;

		private Note note = null;
		private RectTransform rect = null;
		public RectTransform Rect
		{
			get
			{
				if (rect == null)
				{
					rect = GetComponent<RectTransform>();
					if (rect == null) { rect = gameObject.AddComponent<RectTransform>(); }
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
			//unreadDot.gameObject.SetActive(false);
		}
	}
}