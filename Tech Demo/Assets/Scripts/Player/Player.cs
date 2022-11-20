using PatataStudio.DataPersitence;
using PatataStudio.DialogueSystem;
using PatataStudio.Inputs;
using UnityEngine;

namespace PatataStudio.PlayerScript
{
	public class Player : MonoBehaviour, IDataPersistence
	{
		[Header("Menu Panels")]
		[SerializeField] private GameObject pauseMenu;
		[SerializeField] private GameObject optionsMenu;
		[SerializeField] private CanvasGroup canvasGroup;

		[Header("Stats")]
		[SerializeField] private float moveSpeed;
		[SerializeField] private float humanity;
		[SerializeField] private int blood;
		[SerializeField] private int physical;
		[SerializeField] private int social;
		[SerializeField] private int mental;

		private Camera cam;
		private Rigidbody2D playerRB;
		private Animator animator;
		private Vector2 movement;
		private Vector2 dir;
		private Vector2 cursorPos;
		private bool isFacingRight = true;
		private bool gameIsPaused = false;
		public bool noteBookActive = false;
		private SpriteRenderer spriteRendere;



		// Start is called before the first frame update
		private void Start()
		{
			cam = Camera.main;
			playerRB = GetComponent<Rigidbody2D>();
			spriteRendere = GetComponent<SpriteRenderer>();
			//animator = GetComponent<Animator>();
		}

		// Update is called once per frame
		private void Update()
		{
			Vector2 objPos = cam.WorldToScreenPoint(transform.position);
			dir = (InputManager.instance.GetMousePos() - objPos).normalized;

			//animator.SetFloat("SpeedX", Mathf.Abs(playerRB.velocity.x));
			//animator.SetFloat("SpeedY", playerRB.velocity.y);

			if (InputManager.instance.GetPausePressed())
			{
				if (gameIsPaused)
				{
					pauseMenu.SetActive(false);
					optionsMenu.SetActive(false);
					Time.timeScale = 1f;
					gameIsPaused = false;
					return;
				}
				pauseMenu.SetActive(true);
				optionsMenu.SetActive(false);
				Time.timeScale = 0f;
				gameIsPaused = true;
			}

			if (InputManager.instance.GetTabPressed())
			{
				switch (!noteBookActive)
				{
					case true:
						canvasGroup.alpha = 1f;
						canvasGroup.blocksRaycasts = true;
						canvasGroup.interactable = true;
						noteBookActive = true;
						break;

					case false:
						canvasGroup.alpha = 0f;
						canvasGroup.blocksRaycasts = false;
						canvasGroup.interactable = false;
						noteBookActive = false;
						break;
				}
			}
		}

		// Update is called once per fixed time 0.03333334 seconds (30 calls per second)
		private void FixedUpdate()
		{
			movement = InputManager.instance.GetMovement();
			if (DialogueManager.GetInstance().dialogueIsPlaying || noteBookActive)
			{
				playerRB.velocity = Vector2.zero;
				return;
			}

			playerRB.velocity = new Vector2(movement.x * moveSpeed, movement.y * moveSpeed);

			if (movement.x > 0 && !isFacingRight || movement.x < 0 && isFacingRight)
			{
				isFacingRight ^= true;
				spriteRendere.flipX ^= true;
			}
		}

		//#region Controls
		//public void Move(InputAction.CallbackContext ctx)
		//{
		//	inputX = ctx.ReadValue<Vector2>().x;
		//	inputY = ctx.ReadValue<Vector2>().y;
		//}
		//
		//public void Look(InputAction.CallbackContext ctx)
		//{
		//	cursorPos = ctx.ReadValue<Vector2>();
		//}
		//
		//public void Fire(InputAction.CallbackContext ctx)
		//{
		//	fire = ctx.ReadValue<float>();
		//}
		//#endregion

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