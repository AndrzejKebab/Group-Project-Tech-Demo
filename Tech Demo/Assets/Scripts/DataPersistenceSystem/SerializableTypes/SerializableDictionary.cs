using System.Collections.Generic;
using UnityEngine;

namespace PatataStudio.DataPersitence.Serializables
{
	[System.Serializable]
	public class SerializableDictionary<TKey, TValues> : Dictionary<TKey, TValues>, ISerializationCallbackReceiver
	{
		[SerializeField] private List<TKey> keys = new List<TKey>();
		[SerializeField] private List<TValues> values = new List<TValues>();

		public void OnBeforeSerialize()
		{
			keys.Clear();
			values.Clear();

			foreach (KeyValuePair<TKey, TValues> pair in this)
			{
				keys.Add(pair.Key);
				values.Add(pair.Value);
			}
		}

		public void OnAfterDeserialize()
		{
			Clear();

			if (keys.Count != values.Count)
			{
				Debug.LogError("Tried to deserialize SerializableDictionary, but amount of keys (" + keys.Count + ") doesn't match the number of values(" + values.Count + ") which means something went wrong");
			}

			for (int i = 0; i < keys.Count; i++) Add(keys[i], values[i]);
		}
	}
}