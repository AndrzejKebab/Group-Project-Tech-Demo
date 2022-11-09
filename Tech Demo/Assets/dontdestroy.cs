using UnityEngine;

public class dontdestroy : MonoBehaviour
{
	public static dontdestroy managersInstance;

	private void Awake()
	{
		if (managersInstance != null && managersInstance != this)
		{
			Destroy(this.gameObject);
			return;
		}
		managersInstance = this;
		DontDestroyOnLoad(this);
	}
}
