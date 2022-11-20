using UnityEngine;

namespace PatataStudio.Battle
{
	public class Unit : MonoBehaviour
	{
		public string unitName;
		public int unitLevel;
		public int damage;
		public int maxHealth;
		public int currentHeath;

		public bool TakeDamage(int damage)
		{
			currentHeath -= damage;
			Debug.Log("Took damage " + damage);
			
			if(currentHeath <= 0 )
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		public void Heal(int amount)
		{
			currentHeath += amount;
			if(currentHeath > maxHealth)
			{
				currentHeath = maxHealth;
			}
		}
	}
}
