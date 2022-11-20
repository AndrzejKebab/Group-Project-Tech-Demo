using PatataStudio.Battle;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PatataStudio.BattleState
{
	public class Yield : State
	{
		public Yield(BattleSystem battleSystem) : base(battleSystem)
		{
		}

		public override IEnumerator Start()
		{
			BattleSystem.BattleLog.text = $"{BattleSystem.EnemyUnit.unitName} has shit his self!";
			yield return new WaitForSeconds(3);
			SceneManager.LoadSceneAsync(1);
			yield break;
		}
	}
}
