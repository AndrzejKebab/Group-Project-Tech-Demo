using PatataStudio.Battle;
using PatataStudio.BattleState;
using System.Collections;

namespace PatataStudio.BattleState
{
	public class Won : State
	{
		public Won(BattleSystem battleSystem) : base(battleSystem)
		{
		}

		public override IEnumerator Start()
		{
			BattleSystem.BattleLog.text = "You won!";
			yield break;
		}

	}
}