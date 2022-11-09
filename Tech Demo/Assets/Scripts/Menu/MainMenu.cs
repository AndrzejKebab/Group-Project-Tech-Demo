using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
	[Header("Menu Navigation")]
	[SerializeField] private SaveSlotsMenu saveSlotsMenu;

	[Header("Menu Buttons")]
	[SerializeField] private Button newGameButton;
	[SerializeField] private Button continueButton;
	[SerializeField] private Button loadGameButton;

	private void Start()
	{
		if (!DataPersistenceManager.instance.HasGameData())
		{
			continueButton.interactable = false;
			loadGameButton.interactable = false;
		}
	}

	public void NewGame()
	{
		saveSlotsMenu.ActivateMenu(false);
		this.DeactivateMenu();
	}

	public void Continue()
	{
		this.DisableMenuButtons();
		DataPersistenceManager.instance.SaveGame();
		SceneManager.LoadSceneAsync(DataPersistenceManager.instance.GetSavedSceneIndex());
	}

	public void LoadGame()
	{
		saveSlotsMenu.ActivateMenu(true);
		this.DeactivateMenu();
	}

	public void Exit()
	{
		Application.Quit();
	}

	private void DisableMenuButtons()
	{
		newGameButton.interactable = false;
		continueButton.interactable = false;
	}

	public void ActivateMenu()
	{
		this.gameObject.SetActive(true);
	}

	public void DeactivateMenu()
	{
		this.gameObject.SetActive(false);
	}
}
