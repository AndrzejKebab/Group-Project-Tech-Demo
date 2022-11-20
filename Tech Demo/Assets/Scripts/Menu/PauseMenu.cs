using PatataStudio.DataPersitence.Manager;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PatataStudio.Menu
{
	public class PauseMenu : MonoBehaviour
	{
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