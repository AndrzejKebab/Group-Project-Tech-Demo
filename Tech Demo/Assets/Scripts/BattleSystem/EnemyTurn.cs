using PatataStudio.Battle;
using System.Collections;
using UnityEngine;

namespace PatataStudio.BattleState
{
	public class EnemyTurn : State
	{
		public EnemyTurn(BattleSystem battleSystem) : base(battleSystem)
		{
		}

		public override IEnumerator Start()
		{
			if (BattleSystem.EnemyUnit.currentHeath <= BattleSystem.EnemyUnit.maxHealth * 0.2f)
			{
				BattleSystem.SetState(new Yield(BattleSystem));
				yield break;
			}

			BattleSystem.BattleLog.text = $"{BattleSystem.EnemyUnit.unitName} attacks!";

			yield return new WaitForSeconds(3);

			bool isDead = BattleSystem.PlayerUnit.TakeDamage(BattleSystem.EnemyUnit.damage);

			BattleSystem.EnemyGUI.SetHealth(BattleSystem.EnemyUnit.currentHeath);

			yield return new WaitForSeconds(3);

			if (isDead)
			{
				BattleSystem.SetState(new Lost(BattleSystem));
			}
			else
			{
				BattleSystem.SetState(new PlayerTurn(BattleSystem));
			}
		}
	}
}