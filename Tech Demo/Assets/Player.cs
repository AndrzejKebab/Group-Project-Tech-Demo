using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Player : MonoBehaviour , IDataPersistence
{
	[Header("Menu Panels")]
	[SerializeField] private GameObject pauseMenu;
	[SerializeField] private GameObject optionsMenu;
	//[SerializeField] private GameObject noteBookMenu;
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
	private float inputX;
	private float inputY;
	private float fire;
	Vector2 dir;
	Vector2 cursorPos;
	private bool isFacingRight = true;
	private bool gameIsPaused = false;
	public bool noteBookActive = false;



	// Start is called before the first frame update
	private void Start()
	{
		cam = Camera.main;
		playerRB = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
	}

	// Update is called once per frame
	private void Update()
	{
		Vector2 objPos = cam.WorldToScreenPoint(transform.position);
		dir = (cursorPos - objPos).normalized;

		animator.SetFloat("SpeedX", Mathf.Abs(playerRB.velocity.x));
		animator.SetFloat("SpeedY", playerRB.velocity.y);

		if (InputManager.GetInstance().GetPausePressed())
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

		if (InputManager.GetInstance().GetTabPressed())
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

	// Update is called once per fixed time 0.02 seconds (50 calls per second)
	private void FixedUpdate()
	{
		if (DialogueManager.GetInstance().dialogueIsPlaying || noteBookActive)
		{
			playerRB.velocity = Vector2.zero;
			return;
		}

		playerRB.velocity = new Vector2(inputX * moveSpeed, inputY * moveSpeed);

		if ((inputX > 0 && !isFacingRight) || (inputX < 0 && isFacingRight))
		{
			Flip();
		}
	}

	void Flip()
	{
		isFacingRight ^= true;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	#region Controls
	public void Move(InputAction.CallbackContext ctx)
	{
		inputX = ctx.ReadValue<Vector2>().x;
		inputY = ctx.ReadValue<Vector2>().y;
	}

	public void Look(InputAction.CallbackContext ctx)
	{
		cursorPos = ctx.ReadValue<Vector2>();
	}

	public void Fire(InputAction.CallbackContext ctx)
	{
		fire = ctx.ReadValue<float>();
	}
	#endregion

	#region Save & Load Data
	public void LoadData(GameData data)
	{
		this.transform.position = data.playerPosition;
	}

	public void SaveData(GameData data)
	{
		data.playerPosition = this.transform.position;
	}
	#endregion
}
