using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class ConfirmationPopUpMenu : MonoBehaviour
{
	[Header("Components")]
	[SerializeField] private TextMeshProUGUI displayedText;
	[SerializeField] private Button confirmButton;
	[SerializeField] private Button abortButton;

	public void ActivateMenu(string displayedText, UnityAction confirmAction, UnityAction abortAction)
	{
		this.gameObject.SetActive(true);

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
		this.gameObject.SetActive(false);
	}
}
