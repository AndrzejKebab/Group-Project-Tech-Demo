using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	public static GameManager instance { get; private set; }

	private void Awake()
	{
		if (instance != null)
		{
			Debug.Log("More than one Game Manager in scene. Destroyed the newest one.");
			Destroy(this.gameObject);
			return;
		}
		instance = this;
		DontDestroyOnLoad(this.gameObject);

		Application.targetFrameRate = 60;
	}
}