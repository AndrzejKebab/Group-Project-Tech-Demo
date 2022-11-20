using PatataStudio.BattleState;
using TMPro;
using UnityEngine;

namespace PatataStudio.Battle
{
	public class BattleSystem : StateMachine
	{
		#region Init
		[SerializeField] private GameObject playerPrefab;
		public GameObject PlayerPrefab => playerPrefab;
		[SerializeField] private GameObject enemyPrefab;
		public GameObject EnemyPrefab => enemyPrefab;

		[SerializeField] private Transform playerSpawn;
		public Transform PlayerSpawn => playerSpawn;
		[SerializeField] private Transform enemySpawn;
		public Transform EnemySpawn => enemySpawn;

		[SerializeField] private TextMeshProUGUI battleLog;
		public TextMeshProUGUI BattleLog => battleLog;

		[SerializeField] private BattleGUI playerGUI;
		public BattleGUI PlayerGUI => playerGUI;
		[SerializeField] private BattleGUI enemyGUI;
		public BattleGUI EnemyGUI => enemyGUI;

		private Unit playerUnit;
		public Unit PlayerUnit => playerUnit;
		private Unit enemyUnit;
		public Unit EnemyUnit => enemyUnit;
		#endregion

		private void Awake()
		{
			playerGUI = playerPrefab.GetComponent<BattleGUI>();
			enemyGUI = enemyPrefab.GetComponent<BattleGUI>();
		}

		private void Start()
		{
			GameObject playerGameObject = Instantiate(playerPrefab, playerSpawn);
			playerUnit = playerGameObject.GetComponent<Unit>();

			GameObject enemyGameObject = Instantiate(enemyPrefab, enemySpawn);
			enemyUnit = enemyGameObject.GetComponent<Unit>();

			SetState(new Begin(this));
		}

		public void Attack()
		{
			StartCoroutine(State.Attack());
		}

		public void Defense()
		{
			StartCoroutine(State.Defense());
		}
	}
}
