using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace PatataStudio.Menu
{
	public class ConfirmationPopUpMenu : MonoBehaviour
	{
		[Header("Components")]
		[SerializeField] private TextMeshProUGUI displayedText;
		[SerializeField] private Button confirmButton;
		[SerializeField] private Button abortButton;

		public void ActivateMenu(string displayedText, UnityAction confirmAction, UnityAction abortAction)
		{
			gameObject.SetActive(true);

			this.displayedText.text = displayedText;

			confirmButton.onClick.RemoveAllListeners();
			abortButton.onClick.RemoveAllListeners();

			confirmButton.onClick.AddListener(() =>
			{
				DeactivateMenu();
				confirmAction();
			});
			abortButton.onClick.AddListener(() =>
			{
				DeactivateMenu();
				abortAction();
			});
		}

		private void DeactivateMenu()
		{
			gameObject.SetActive(false);
		}
	}
}