using PatataStudio.Inputs;
using PatataStudio.PlayerScript;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace PatataStudio.NoteBookSystem
{
	[Serializable()]
	public struct UIElements
	{
		[SerializeField] private TextMeshProUGUI textObj;
		public TextMeshProUGUI TextObj { get { return textObj; } }
	
		[SerializeField] private TextMeshProUGUI subscript;
		public TextMeshProUGUI Subscript { get { return subscript; } }
	
		[SerializeField] private CanvasGroup subscriptGroup;
		public CanvasGroup SubscriptGroup { get { return subscriptGroup; } }
	
		[SerializeField] private Image page;
		public Image Page { get { return page; } }
	
		[SerializeField] private Image lines;
		public Image Lines { get { return lines; } }
	
		[SerializeField] private CanvasGroup noteCanvasGroup;
		public CanvasGroup NoteCanvasGroup { get { return noteCanvasGroup; } }
	
		[SerializeField] private CanvasGroup listCanvasGroup;
		public CanvasGroup ListCanvasGroup { get { return listCanvasGroup; } }
	
		[SerializeField] private CanvasGroup readButton;
		public CanvasGroup ReadButton { get { return readButton; } }
	
		[SerializeField] private CanvasGroup nextButton;
		public CanvasGroup NextButton { get { return nextButton; } }
	
		[SerializeField] private CanvasGroup previousButton;
		public CanvasGroup PreviousButton { get { return previousButton; } }
	
		[SerializeField] public NoteData noteDataPrefab;
		public NoteData NoteDataPrefab { get { return noteDataPrefab; } }
	
		[SerializeField] private RectTransform listRect;
		public RectTransform ListRect { get { return listRect; } }
	}
	
	public class NoteSystem : MonoBehaviour
	{
		#region Action & Data
	[SerializeField] private UIElements UI = new UIElements();

	[SerializeField] private Color color1 = Color.black;
	[SerializeField] private Color color2 = Color.white;

	private Dictionary<string, Note> Notes = new Dictionary<string, Note>();
	private List<NoteData> noteDatas = new List<NoteData>();
	private Action<Note> A_Display = delegate { };
	#endregion
	
		#region Audio
	[SerializeField] private AudioSource[] sources = null;
	[Space]
	[SerializeField] private AudioClip openNoteSFX = null;
	[SerializeField] private AudioClip closeNoteSFX = null;
	[Space]
	[SerializeField] private AudioClip[] turnPageSFX = null;
	#endregion
	
		#region Properties & Private

	private Note activeNote = null;
	private Page ActivePage
	{
		get
		{
			return activeNote.Pages[currentPage];
		}
	}
	private int currentPage = 0;
	private bool readSubscript = false;
	private Sprite defaultPageTexture = null;
	private bool usingNoteSystem;
	#endregion
	
		private void OnEnable()
		{
			A_Display += DisplayNote;
		}
		
		private void OnDisable()
		{
			A_Display -= DisplayNote;
		
		}
	
		private void Start()
		{
			Close(false);
			defaultPageTexture = UI.Page.sprite;
		}
	
		private void Update()
		{
			if (InputManager.instance.GetTabPressed())
			{
				usingNoteSystem = !usingNoteSystem;
	
				switch (usingNoteSystem)
				{
					case true:
						Open();
						break;
					case false:
						Close(activeNote != null);
						break;
				}
			}
		}
	
		public void Open()
		{
			UpdateList();
			UpdateCanvasGroup(true, UI.ListCanvasGroup);
			SwitchGameControls(false);
		}
	
		[SerializeField] private GameObject player;
		private void SwitchGameControls(bool state)
		{
			switch (state)
			{
				case true:
					player.GetComponent<Player>().noteBookActive = false;
					break;
				case false:
					player.GetComponent<Player>().noteBookActive = true;
					break;
			}
	
		}
	
		public void Close(bool playSFX)
		{
			CloseNote(playSFX);
			UpdateCanvasGroup(false, UI.ListCanvasGroup);
		}
	
		private void DisplayNote(Note note)
		{
			if (note == null) return;
	
			SwitchGameControls(false);
	
			PlaySound(openNoteSFX);
	
			UpdateCanvasGroup(true, UI.NoteCanvasGroup);
			activeNote = note;
	
			DisplayPage(0);
		}
	
		private void DisplayPage(int page)
		{
			UI.ReadButton.interactable = activeNote.Pages[page].Type == PageType.Texture;
	
			if (activeNote.Pages[page].Type != PageType.Texture)
			{
				readSubscript = false;
			}
			else if (readSubscript)
			{
				UpdateSubscript();
			}
	
			sources[1].Stop();
			if (activeNote.Pages[page].Narration != null)
			{
				sources[1].clip = activeNote.Pages[page].Narration;
				sources[1].Play();
				if (activeNote.Pages[page].Narration_PlayOnce)
				{
					activeNote.Pages[page].NarrationPlayed = true;
				}
			}
	
			switch (activeNote.Pages[page].Type)
			{
				case PageType.Text:
					UI.Page.sprite = defaultPageTexture;
					UI.TextObj.text = activeNote.Pages[page].Text;
					break;
				case PageType.Texture:
					UI.Page.sprite = activeNote.Pages[page].Texture;
					UI.TextObj.text = String.Empty;
					break;
			}
			UpdateUI();
		}
	
		public void Display(Note note)
		{
			A_Display(note);
		}
		
		public void Display(string key)
		{
			var note = GetNote(key);
			A_Display(note);
		}
	
		public void CloseNote(bool playSFX)
		{
			if (playSFX)
			{
				PlaySound(closeNoteSFX);
			}
			UpdateCanvasGroup(false, UI.NoteCanvasGroup);
			OnNoteClose();
		}
	
		private void UpdateUI()
		{
			UI.PreviousButton.interactable = !(currentPage == 0);
			UI.NextButton.interactable = !(currentPage == activeNote.Pages.Length - 1);
	
			var useSubscript = ActivePage.Type == PageType.Texture && ActivePage.UseSubscript;
			UI.ReadButton.alpha = useSubscript ? (readSubscript ? .5f : 1f) : 0f;
			UpdateCanvasGroup(readSubscript, UI.SubscriptGroup);
	
			UI.Lines.enabled = ActivePage.DisplayLines;
		}
	
		private void UpdateList()
		{
			ClearList();
	
			var index = 0;
			var height = 0.0f;
			foreach(var note in Notes)
			{
				var color = index % 2 == 0 ? color1 : color2;
	
				var newNotePrefab = Instantiate(UI.NoteDataPrefab, UI.ListRect);
				noteDatas.Add(newNotePrefab);
	
				newNotePrefab.UpdateInfo(note.Value, color);
	
				newNotePrefab.Rect.anchoredPosition = new Vector2(0, height);
				height -= newNotePrefab.Rect.sizeDelta.y;
	
				UI.ListRect.sizeDelta = new Vector2(UI.ListRect.sizeDelta.x, height * -1);
	
				index++;
			}
		}
	
		private void UpdateSubscript()
		{
			UI.Subscript.text = readSubscript ? ActivePage.Text : string.Empty;
		}
	
		public void Next()
		{
			PlaySound(turnPageSFX);
			currentPage++;
			DisplayPage(currentPage);
		}
	
		public void Previous()
		{
			PlaySound(turnPageSFX);
			currentPage--;
			DisplayPage(currentPage);
		}
	
		public void Read()
		{
			readSubscript = !readSubscript; 
	
			UpdateSubscript();
			UpdateUI();
		}
	
		public void ClearList()
		{
			foreach (var note in noteDatas)
			{
				Destroy(note.gameObject);
			}
	
			noteDatas.Clear();
		}
	
		private void OnNoteClose()
		{
			activeNote = null;
			currentPage = 0;
			readSubscript = false;
			sources[1].Stop();
			if (!usingNoteSystem)
			{
				SwitchGameControls(true);
			}
		}
	
		private void UpdateCanvasGroup(bool state, CanvasGroup canvasGroup)
		{
			switch (state)
			{
				case true:
					canvasGroup.alpha = 1f;
					canvasGroup.blocksRaycasts = true;
					canvasGroup.interactable = true;
					break;
	
				case false:
					canvasGroup.alpha = 0f;
					canvasGroup.blocksRaycasts = false;
					canvasGroup.interactable = false;
					break;
			}
		}
	
		public void AddNote(string key, Note note)
		{
			if(Notes.ContainsKey(key) == false)
			{
				Notes.Add(key, note);
			}
		}
	
		private void PlaySound(AudioClip clip)
		{
			if (clip)
			{
				sources[0].PlayOneShot(clip);
			}
		}
	
		private void PlaySound(AudioClip[] clips)
		{
			if(clips != null)
			{
				var sfx = clips[UnityEngine.Random.Range(0, clips.Length)];
				sources[0].PlayOneShot(sfx);
			}
		}
	
		public Note GetNote(string key)
		{
			if (Notes.ContainsKey(key))
			{
				return Notes[key];
			}
			else
			{
				return null;
			}
		}
	}
}
