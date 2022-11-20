using PatataStudio.Battle;
using System.Collections;

namespace PatataStudio
{
	public abstract class State
	{
		protected BattleSystem BattleSystem;

		public State(BattleSystem battleSystem)
		{
			this.BattleSystem = battleSystem;
		}

		public virtual IEnumerator Start()
		{
			yield break;
		}

		public virtual IEnumerator Attack()
		{
			yield break;
		}

		public virtual IEnumerator Defense()
		{
			yield break;
		}
	}
}
