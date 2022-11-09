using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class InputManager : MonoBehaviour
{
	private bool interactPressed = false;
	private bool submitPressed = false;
	private bool pausePressed = false;
	private bool tabPressed = false;

	private static InputManager instance;

	private void Awake()
	{
		if (instance != null)
		{
			Debug.Log("More than one Input Manager in scene.");
			return;
		}
		instance = this;
	}

	public static InputManager GetInstance()
	{
		return instance;
	}

	public void InteractButtonPressed(InputAction.CallbackContext context)
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

	public void RegisterSubmitPressed()
	{
		submitPressed = false;
	}
}
