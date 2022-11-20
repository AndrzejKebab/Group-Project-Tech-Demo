using PatataStudio.Battle;
using System.Collections;
using UnityEngine;

namespace PatataStudio.BattleState
{
	public class PlayerTurn : State
	{
		public PlayerTurn(BattleSystem battleSystem) : base(battleSystem) 
		{	
		}

		public override IEnumerator Start()
		{
			BattleSystem.BattleLog.text = "Chooose!";
			yield break;
		}

		public override IEnumerator Attack()
		{
			bool isDead = BattleSystem.EnemyUnit.TakeDamage(BattleSystem.PlayerUnit.damage);

			BattleSystem.EnemyGUI.SetHealth(BattleSystem.EnemyUnit.currentHeath);
			BattleSystem.BattleLog.text = "The attack is successful!";

			yield return new WaitForSeconds(3);

			if (isDead)
			{
				BattleSystem.SetState(new Won(BattleSystem));
			}
			else
			{
				BattleSystem.SetState(new EnemyTurn(BattleSystem));
			}
		}

		public override IEnumerator Defense()
		{
			BattleSystem.PlayerUnit.Heal(10);

			BattleSystem.EnemyGUI.SetHealth(BattleSystem.EnemyUnit.currentHeath);
			BattleSystem.BattleLog.text = "You shit yourself!";

			yield return new WaitForSeconds(3);

			BattleSystem.SetState(new EnemyTurn(BattleSystem));
		}
	}
}
