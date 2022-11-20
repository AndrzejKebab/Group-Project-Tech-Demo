using PatataStudio.DataPersitence;
using PatataStudio.DataPersitence.Manager;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace PatataStudio.Menu
{
	public class SaveSlotsMenu : MonoBehaviour
	{
		[Header("Menu Navigation")]
		[SerializeField] private MainMenu mainMenu;

		[Header("Menu Buttons")]
		[SerializeField] private Button backButton;

		[Header("Confirmation Popup")]
		[SerializeField] private ConfirmationPopUpMenu confirmPopUpMenu;

		private SaveSlot[] saveSlots;

		private bool isLoadingGame = false;

		private void Awake()
		{
			saveSlots = GetComponentsInChildren<SaveSlot>();
		}

		public void OnSaveSlotClicked(SaveSlot saveSlot)
		{
			DisableMenuButtons();

			if (isLoadingGame)
			{
				DataPersistenceManager.instance.ChangeSelectedProfileId(saveSlot.GetProfileId());
				SaveGameAndLoadScene();
			}
			else if (saveSlot.hasData)
			{
				confirmPopUpMenu.ActivateMenu(
					"Starting a New Game With this slot will override the currenlty saved data. Are you sure?",
					() =>
					{
						DataPersistenceManager.instance.ChangeSelectedProfileId(saveSlot.GetProfileId());
						DataPersistenceManager.instance.NewGame();
						SaveGameAndLoadScene();
					},
					() =>
					{
						ActivateMenu(isLoadingGame);
					}
				);
			}
			else
			{
				DataPersistenceManager.instance.ChangeSelectedProfileId(saveSlot.GetProfileId());
				DataPersistenceManager.instance.NewGame();
				SaveGameAndLoadScene();
			}
		}

		private void SaveGameAndLoadScene()
		{
			DataPersistenceManager.instance.SaveGame();

			SceneManager.LoadSceneAsync(DataPersistenceManager.instance.GetSavedSceneIndex());
		}

		public void OnBackClicked()
		{
			mainMenu.ActivateMenu();
			DeactiveMenu();
		}

		public void ActivateMenu(bool isLoadingGame)
		{
			gameObject.SetActive(true);

			this.isLoadingGame = isLoadingGame;

			Dictionary<string, GameData> profilesGameData = DataPersistenceManager.instance.GetAllProfilesGameData();

			backButton.interactable = true;

			foreach (SaveSlot saveSlot in saveSlots)
			{
				GameData profileData = null;
				profilesGameData.TryGetValue(saveSlot.GetProfileId(), out profileData);
				saveSlot.SetData(profileData);

				if (profileData == null && isLoadingGame)
				{
					saveSlot.SetInteractable(false);
				}
				else
				{
					saveSlot.SetInteractable(true);
				}
			}
		}
		public void DeactiveMenu()
		{
			gameObject.SetActive(false);
		}

		private void DisableMenuButtons()
		{
			foreach (SaveSlot saveSlot in saveSlots)
			{
				saveSlot.SetInteractable(false);
			}
			backButton.interactable = false;
		}
	}
}