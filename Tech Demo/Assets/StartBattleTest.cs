using PatataStudio.DataPersitence.Manager;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PatataStudio
{
	public class StartBattleTest : MonoBehaviour
	{

		private void OnTriggerStay2D(Collider2D collision)
		{
			if (Input.GetKeyDown(KeyCode.E)) // z jakiego� kurwa powodu nie dzia�a z InputManager.instance.GetInteractPressed() XDDDD
			{
				DataPersistenceManager.instance.SaveGame();
				SceneManager.LoadSceneAsync(2);
			}
		}
	}
}
