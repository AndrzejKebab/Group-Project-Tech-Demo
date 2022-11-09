using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DataPersistenceManager : MonoBehaviour
{
	[Header("Debugging")]
	[SerializeField] private bool disableDataPersistence = false;
	[SerializeField] private bool initializeDataIfNull = false;
	[SerializeField] private bool overrideSelectedProfileId = false;
	[SerializeField] private string testSelectedProfileId = "test";

	[Header("File Storage Config")]
	[SerializeField] private string fileName;
	[SerializeField] private bool useEncryption;

	private GameData gameData;
	private List<IDataPersistence> dataPersistencesObjects;
	private FileDataHandler dataHandler;
	private string selectedProfileId = "";

	public static DataPersistenceManager instance { get; private set; }

	private void Awake()
	{
		if(instance != null)
		{
			Debug.Log("More than one Data Persistence Manager in scene. Destroyed the newest one.");
			Destroy(this.gameObject);
			return;
		}
		instance = this;
		DontDestroyOnLoad(this.gameObject);

		if (disableDataPersistence)
		{
			Debug.LogWarning("Data Persistence is disabled!");
		}

		this.dataHandler = new FileDataHandler(Application.persistentDataPath, fileName, useEncryption);

		this.selectedProfileId = dataHandler.GetMostRecenltyUpdatedProfileId();

		if (overrideSelectedProfileId)
		{
			this.selectedProfileId = testSelectedProfileId;
			Debug.LogWarning("Overrode selected profile id with test id: " + testSelectedProfileId);
		}
	}
	#region OnSceneEvents
	private void OnEnable()
	{
		SceneManager.sceneLoaded += OnSceneLoaded;
	}

	public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
	{
		Debug.Log("Saved on scene Loaded");
		this.dataPersistencesObjects = FindAllDataPersistenceObjects();
		LoadGame();
	}

	private void OnDisable()
	{
		SceneManager.sceneLoaded -= OnSceneLoaded;
	}
	#endregion

	public void ChangeSelectedProfileId(string newProfileId)
	{
		this.selectedProfileId = newProfileId;

		LoadGame();
	}

	public void NewGame()
	{
		this.gameData = new GameData();
	}
	#region Load Game
	public void LoadGame()
	{
		if (disableDataPersistence)
		{
			return;
		}

		this.gameData = dataHandler.Load(selectedProfileId);

		if(this.gameData == null && initializeDataIfNull)
		{
			NewGame();
		}

		if(this.gameData == null)
		{
			Debug.LogWarning("No data found. New Game needs to be started before data can be loaded.");
			return;
		}

		foreach (IDataPersistence dataPersistenceObj in dataPersistencesObjects)
		{
			dataPersistenceObj.LoadData(gameData);
		}

		Debug.Log("Loaded Health: " + gameData.health + " / " + gameData.maxHealth);
	}
	#endregion

	#region Save Game
	public void SaveGame()
	{
		if (disableDataPersistence)
		{
			return;
		}

		if (this.gameData == null)
		{
			Debug.LogWarning("No data found. New Game needs to be started before data can be saved.");
			return;
		}

		foreach (IDataPersistence dataPersistenceObj in dataPersistencesObjects)
		{
			dataPersistenceObj.SaveData(gameData);
		}

		gameData.lastUpdated = System.DateTime.Now.ToBinary();

		Debug.Log("Saved Health: " + gameData.health + " / " + gameData.maxHealth);

		Scene scene = SceneManager.GetActiveScene();
		
		if (!scene.buildIndex.Equals(0))
		{
			gameData.currentSceneIndex = scene.buildIndex;
		}

		dataHandler.Save(gameData, selectedProfileId);
	}

	private void OnApplicationQuit()
	{
		SaveGame();
	}
	#endregion

	private List<IDataPersistence> FindAllDataPersistenceObjects()
	{
		IEnumerable<IDataPersistence> dataPersistencesObjects = FindObjectsOfType<MonoBehaviour>(true).OfType<IDataPersistence>();

		return new List<IDataPersistence>(dataPersistencesObjects);
	}

	public Dictionary<string, GameData> GetAllProfilesGameData()
	{
		return dataHandler.LoadAllProfiles();
	}

	public int GetSavedSceneIndex()
	{
		// error out and return null if we don't have any game data yet
		if (gameData == null)
		{
			Debug.LogError("Tried to get scene index but data was null.");
			return 0;
		}
		
		return gameData.currentSceneIndex;
	}

	public bool HasGameData()
	{
		return this.gameData != null;
	}
}
