using PatataStudio.Battle;
using System.Collections;

namespace PatataStudio.BattleState
{
	public class Lost : State
	{
		public Lost(BattleSystem battleSystem) : base(battleSystem)
		{
		}

		public override IEnumerator Start()
		{
			BattleSystem.BattleLog.text = "You died!";
			yield break;
		}
	}
}