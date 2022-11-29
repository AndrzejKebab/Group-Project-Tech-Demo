using UnityEngine;
using UnityEngine.InputSystem;

namespace PatataStudio.Inputs
{
	[RequireComponent(typeof(PlayerInput))]
	public class InputManager : MonoBehaviour
	{
		private bool interactPressed = false;
		private bool submitPressed = false;
		private bool pausePressed = false;
		private bool tabPressed = false;
		private float fire;
		private Vector2 cursorPos;
		private Vector2 movement;

		public static InputManager instance { get; private set; }

		private void Awake()
		{
			if (instance != null)
			{
				Debug.Log("More than one Input Manager in scene.");
				return;
			}
			instance = this;
		}

		public void Move(InputAction.CallbackContext ctx)
		{
			movement = ctx.ReadValue<Vector2>();
		}

		public void Look(InputAction.CallbackContext ctx)
		{
			cursorPos = ctx.ReadValue<Vector2>();
		}

		public void Fire(InputAction.CallbackContext ctx)
		{
			fire = ctx.ReadValue<float>();
		}

		public void InteractPressed(InputAction.CallbackContext context)
		{
			if (context.performed)
			{
				interactPressed = true;
			}
			else if (context.canceled)
			{
				interactPressed = false;
			}
		}

		public void SubmitPressed(InputAction.CallbackContext context)
		{
			if (context.performed)
			{
				submitPressed = true;
			}
			else if (context.canceled)
			{
				submitPressed = false;
			}
		}

		public void PausePressed(InputAction.CallbackContext context)
		{
			if (context.performed)
			{
				pausePressed = true;
			}
			else if (context.canceled)
			{
				pausePressed = false;
			}
		}

		public void TabPressed(InputAction.CallbackContext context)
		{
			if (context.performed)
			{
				tabPressed = true;
			}
			else if (context.canceled)
			{
				tabPressed = false;
			}
		}

		public bool GetInteractPressed()
		{
			bool result = interactPressed;
			interactPressed = false;
			return result;
		}

		public bool GetSubmitPressed()
		{
			bool result = submitPressed;
			submitPressed = false;
			return result;
		}

		public bool GetPausePressed()
		{
			bool result = pausePressed;
			pausePressed = false;
			return result;
		}

		public bool GetTabPressed()
		{
			bool result = tabPressed;
			tabPressed = false;
			return result;
		}

		public Vector2 GetMousePos()
		{
			return cursorPos;
		}

		public Vector2 GetMovement()
		{
			return movement;
		}

		public void RegisterSubmitPressed()
		{
			submitPressed = false;
		}
	}
}