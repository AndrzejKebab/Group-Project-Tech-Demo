using UnityEngine;

namespace PatataStudio.General
{
	public class Door : MonoBehaviour
	{
		[SerializeField] private Transform doorDestination;


		public Transform GetDestination()
		{
			return doorDestination;
		}
	}
}
