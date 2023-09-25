using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace PlayerInput
{
	[CreateAssetMenu(fileName = "New UIInput Binder", menuName = "Input/UI Input Binder")]
	public class UIInputBinder : ScriptableObject, PlayerControls.IUIActions
	{
		public event Action<Vector2> NavigateEvent;
		public event Action<bool> SubmitEvent;
		public event Action<bool> CancelEvent;
		public event Action<Vector2> PointEvent;
		public event Action<bool> ClickEvent;
		public event Action<Vector2> ScrollWheelEvent;
		public event Action<bool> MiddleClickEvent;
		public event Action<bool> RightClickEvent;


		private PlayerControls _controls = null;

		private void OnEnable()
		{
			if (_controls == null)
			{
				_controls = new PlayerControls();
				_controls.UI.SetCallbacks(this);
			}

			_controls.UI.Enable();
		}

		private void OnDisable()
		{
			_controls.UI.Disable();
		}

		public void OnNavigate(InputAction.CallbackContext context) => NavigateEvent?.Invoke(context.ReadValue<Vector2>());

		public void OnSubmit(InputAction.CallbackContext context)
		{
			if (context.performed) SubmitEvent?.Invoke(true);
		}

		public void OnCancel(InputAction.CallbackContext context)
		{
			if (context.performed) CancelEvent?.Invoke(true);
		}

		public void OnPoint(InputAction.CallbackContext context) => PointEvent?.Invoke(context.ReadValue<Vector2>());

		public void OnClick(InputAction.CallbackContext context)
		{
			if (context.performed) ClickEvent?.Invoke(true);
		}

		public void OnScrollWheel(InputAction.CallbackContext context)=> ScrollWheelEvent?.Invoke(context.ReadValue<Vector2>());

		public void OnMiddleClick(InputAction.CallbackContext context)
		{
			if (context.performed) MiddleClickEvent?.Invoke(true);
		}

		public void OnRightClick(InputAction.CallbackContext context)
		{
			if (context.performed) RightClickEvent?.Invoke(true);
		}
	}
}