using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace PlayerInput
{
	[CreateAssetMenu(fileName = "New Input Binder", menuName = "Input/Player Input Binder")]
	public class PlayerInputBinder : ScriptableObject, PlayerControls.IPlayerActions
	{
		public event Action<Vector2> MoveEvent;
		public event Action<bool> InteractEvent;
		public event Action<bool> PauseEvent;

		private PlayerControls _controls = null;

		private void OnEnable()
		{
			if (_controls == null)
			{
				_controls = new PlayerControls();
				_controls.Player.SetCallbacks(this);
			}

			_controls.Enable();
		}

		private void OnDisable()
		{
			_controls.Disable();
		}

		public void OnMove(InputAction.CallbackContext context) => MoveEvent?.Invoke(context.ReadValue<Vector2>());


		public void OnInteract(InputAction.CallbackContext context)
		{
			if (context.performed) InteractEvent?.Invoke(true);
		}

		public void OnPause(InputAction.CallbackContext context)
		{
			if (context.performed) InteractEvent?.Invoke(true);
		}
	}
}