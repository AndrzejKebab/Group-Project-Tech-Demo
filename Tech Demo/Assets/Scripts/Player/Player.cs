using PatataStudio.DataPersitence;
using PatataStudio.DialogueSystem;
using PatataStudio.Inputs;
using UnityEngine;

namespace PatataStudio.PlayerScript
{
	public class Player : MonoBehaviour, IDataPersistence
	{
		[Header("Menu Panels")]
		[SerializeField] private CanvasGroup canvasGroup;

		[Header("Stats")]
		[SerializeField] private float moveSpeed;
		[SerializeField] private float humanity;
		[SerializeField] private int blood;
		[SerializeField] private int physical;
		[SerializeField] private int social;
		[SerializeField] private int mental;

		private Rigidbody2D playerRB;
		private Animator animator;
		private Vector2 movement;
		private bool isFacingRight = true;
		public bool noteBookActive;
		private SpriteRenderer spriteRendere;

		private void Start()
		{
			playerRB = GetComponent<Rigidbody2D>();
			spriteRendere = GetComponent<SpriteRenderer>();
			//animator = GetComponent<Animator>();
		}

		private void Update()
		{
			//animator.SetFloat("SpeedX", Mathf.Abs(playerRB.velocity.x));
			//animator.SetFloat("SpeedY", playerRB.velocity.y);
		}

		// Update is called once per fixed time 0.01666667 seconds (60 calls per second)
		private void FixedUpdate()
		{
			if (DialogueManager.instance.dialogueIsPlaying || noteBookActive)
			{
				playerRB.velocity = Vector2.zero;
				return;
			}

			movement = InputManager.instance.GetMovement();
			playerRB.velocity = new Vector2(movement.x * moveSpeed, movement.y * moveSpeed);

			if (movement.x > 0 && !isFacingRight || movement.x < 0 && isFacingRight)
			{
				isFacingRight ^= true;
				spriteRendere.flipX ^= true;
			}
		}

		#region Save & Load Data
		public void LoadData(GameData data)
		{
			transform.position = data.playerPosition;
		}

		public void SaveData(GameData data)
		{
			data.playerPosition = transform.position;
		}
		#endregion
	}
}