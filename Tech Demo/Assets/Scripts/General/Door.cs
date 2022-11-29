using PatataStudio.Inputs;
using UnityEngine;

namespace PatataStudio.General
{
	public class Door : MonoBehaviour
	{
		[SerializeField] private Transform doorDestination;
		private Transform player;

		private void Awake()
		{
			player = GameObject.FindGameObjectWithTag("Player").transform;
		}

		private void OnTriggerStay2D(Collider2D collision)
		{
			if (InputManager.instance.GetInteractPressed())
			{
				player.position = doorDestination.position;
			}
		}
	}
}
