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
		public int maxHealth;
		public float health;
		public Vector3 playerPosition;
		public SerializableDictionary<string, bool> testStuff;

		public GameData()
		{
			currentSceneIndex = 1;

			globalVariablesStateJson = "";
			maxHealth = 100;
			health = maxHealth;
			playerPosition = Vector3.zero;
			testStuff = new SerializableDictionary<string, bool>();
		}
	}
}