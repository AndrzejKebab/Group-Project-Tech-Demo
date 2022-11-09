using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class testDoor : MonoBehaviour , IDataPersistence
{
	[SerializeField] private string id;
	[SerializeField] private int sceneIndex;
	[SerializeField] private Vector3 playerOut;
	[SerializeField] private GameObject player;

	[ContextMenu("Generate guid for id")]
	private void GenerateGuid()
	{
		id = System.Guid.NewGuid().ToString();
	}

	private bool touched = false;
	[SerializeField] private bool isDoor;

	public void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player") && isDoor)
		{
			player.transform.localPosition = playerOut;
		}
		else if(touched == false)
		{
			Vector3 testA = transform.localPosition;
			testA.x += 1;
			transform.localPosition = testA;
			Debug.Log("touch");
			touched = true;
		}
	}

	public void LoadData(GameData data)
	{
		data.testStuff.TryGetValue(id, out touched);
		if(touched == true)
		{
			Destroy(this.gameObject);
		}
	}

	public void SaveData(GameData data)
	{
		if (data.testStuff.ContainsKey(id))
		{
			data.testStuff.Remove(id);
		}
		data.testStuff.Add(id, touched);
	}
}
