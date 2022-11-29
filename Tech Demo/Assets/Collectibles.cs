using PatataStudio.DataPersitence;
using PatataStudio.DialogueSystem;
using TMPro;
using UnityEngine;

public class Collectibles : MonoBehaviour , IDataPersistence
{
	private int circlesPicked;
	[SerializeField] private TextMeshProUGUI circlesTxt;
	[SerializeField] private string id;
	private bool isCollected = false;

	[ContextMenu("Generate guid for id")]
	private void GenerateGuid()
	{
		id = System.Guid.NewGuid().ToString();
	}

	// Update is called once per frame
	void Update()
	{
		circlesPicked = ((Ink.Runtime.IntValue)DialogueManager.instance.GetVariableState("circlesPicked")).value;
		Debug.Log("Circles amount: " + circlesPicked);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			circlesPicked++;
			Ink.Runtime.Object obj = new Ink.Runtime.IntValue(circlesPicked);
			DialogueManager.instance.SetVariableState("circlesPicked", obj);
			this.gameObject.SetActive(false);
			isCollected = true;
		}
	}

	public void LoadData(GameData data)
	{
		//data.testStuff.TryGetValue(id, out isCollected);
		//if (isCollected == true)
		//{
		//	Destroy(this.gameObject);
		//}
	}

	public void SaveData(GameData data)
	{
		//if (data.testStuff.ContainsKey(id))
		//{
		//	data.testStuff.Remove(id);
		//}
		//data.testStuff.Add(id, isCollected);
	}
}
