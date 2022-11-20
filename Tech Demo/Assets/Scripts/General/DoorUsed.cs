using UnityEngine;
using PatataStudio.Inputs;

namespace PatataStudio.General
{
	public class DoorUsed : MonoBehaviour
	{
		private GameObject currentDoor;

		private void OnTriggerEnter2D(Collider2D collision)
		{
			if (collision.CompareTag("Door"))
			{
				currentDoor = collision.gameObject;
			}
		}

		private void OnTriggerStay2D(Collider2D collision)
		{
			if (InputManager.instance.GetInteractPressed() && collision.CompareTag("Door"))
			{
				transform.position = currentDoor.GetComponent<Door>().GetDestination().position;
			}
		}

		private void OnTriggerExit2D(Collider2D collision)
		{
			if (collision.CompareTag("Door") && collision.gameObject == currentDoor)
			{
				currentDoor = null;
			}
		}
	}
}
