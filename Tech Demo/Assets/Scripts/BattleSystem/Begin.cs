using PatataStudio.Battle;
using System.Collections;
using UnityEngine;

namespace PatataStudio.BattleState
{
	public class Begin : State
	{
		public Begin(BattleSystem battleSystem) : base(battleSystem)
		{

		}

		public override IEnumerator Start()
		{
			BattleSystem.BattleLog.text = "You are attacked by " + BattleSystem.EnemyUnit.unitName + ".";

			BattleSystem.PlayerGUI.SetGUI(BattleSystem.PlayerUnit);
			BattleSystem.EnemyGUI.SetGUI(BattleSystem.EnemyUnit);

			yield return new WaitForSeconds(3);

			BattleSystem.SetState(new PlayerTurn(BattleSystem));
		}
	}
}
