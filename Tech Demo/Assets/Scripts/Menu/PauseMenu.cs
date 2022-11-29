using PatataStudio.DataPersitence.Manager;
using PatataStudio.Inputs;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PatataStudio.Menu
{
	public class PauseMenu : MonoBehaviour
	{
		[Header("Menu Panels")]
		[SerializeField] private GameObject pauseMenu;
		[SerializeField] private GameObject optionsMenu;

		private bool gameIsPaused = false;

		private void Update()
		{
			if (InputManager.instance.GetPausePressed())
			{
				if (gameIsPaused)
				{
					pauseMenu.SetActive(false);
					optionsMenu.SetActive(false);
					Time.timeScale = 1f;
					gameIsPaused = false;
					return;
				}
				pauseMenu.SetActive(true);
				optionsMenu.SetActive(false);
				Time.timeScale = 0f;
				gameIsPaused = true;
			}
		}
		public void SaveGame()
		{
			DataPersistenceManager.instance.SaveGame();
		}

		public void BackToMenu()
		{
			Time.timeScale = 1f;
			SceneManager.LoadScene(0);
		}
	}
}