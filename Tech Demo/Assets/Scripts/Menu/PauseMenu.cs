using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
