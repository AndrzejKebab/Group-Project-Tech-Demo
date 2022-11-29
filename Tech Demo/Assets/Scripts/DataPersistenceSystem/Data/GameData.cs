using PatataStudio.DataPersitence.Serializables;
using UnityEngine;

namespace PatataStudio.DataPersitence
{
	[System.Serializable]
	public class GameData
	{
		public long lastUpdated;

		public string globalVariablesStateJson;
		public int currentSceneIndex;
		public Vector3 playerPosition;
		public SerializableDictionary<string, bool> CollectedNotes;

		public GameData()
		{
			currentSceneIndex = 1;

			globalVariablesStateJson = "";
			playerPosition = new Vector3(-50, 55, 0);
			CollectedNotes = new SerializableDictionary<string, bool>();
		}
	}
}