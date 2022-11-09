using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SaveSlot : MonoBehaviour
{
	[Header("Profile")]
	[SerializeField] private string profileId = "";

	[Header("Content")]
	[SerializeField] private GameObject noDataContent;
	[SerializeField] private GameObject hasDataContent;
	[SerializeField] private TextMeshProUGUI mainPlotCompleted;
	[SerializeField] private TextMeshProUGUI sideQuestsCompleted;

	public bool hasData { get; private set; } = false;

	private Button saveSlotButton;

	private void Awake()
	{
		saveSlotButton = this.GetComponent<Button>();
	}

	public void SetData(GameData data)
	{
		if(data == null)
		{
			hasData = false;
			noDataContent.SetActive(true);
			hasDataContent.SetActive(false);
		}
		else
		{
			hasData = true;
			noDataContent.SetActive(false);
			hasDataContent.SetActive(true);
		}
	}

	public string GetProfileId()
	{
		return this.profileId;
	}

	public void SetInteractable(bool interactable)
	{
		saveSlotButton.interactable = interactable;
	}
}
