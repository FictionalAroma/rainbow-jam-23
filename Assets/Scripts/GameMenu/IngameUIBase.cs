using System;
using CommonComponents.Interfaces;
using Management;
using UnityEngine;
using UnityEngine.EventSystems;

namespace GameMenu
{
	public class IngameUIBase : MonoBehaviour
	{
		[SerializeField] private Canvas canvas;
		
		protected IngameUIBase PreviousMenu;
		private EventSystem _eventSystem;
		private GameObject _lastObject;
		[SerializeField]private GameObject firstSelect;

		private Action _onCloseCallback;

		public void Awake()
		{
			_eventSystem = EventSystem.current;
		}


		public virtual bool ShowMenu(IngameUIBase previous = null, Action onCloseCallback = null)
		{
			_onCloseCallback = onCloseCallback;
			PreviousMenu = previous;
			ReturnFocus();
			return true;
		}


		public virtual void CloseMenu()
		{
			canvas.gameObject.SetActive(false);

			if (PreviousMenu != null)
			{
				PreviousMenu.ReturnFocus();
			}
			else
			{ 
				_onCloseCallback?.Invoke();
				GameStateManager.Instance.SetState(GameState.Running);
			}
		}

		protected virtual void ReturnFocus()
		{
			canvas.gameObject.SetActive(true);
			
			_eventSystem.SetSelectedGameObject(_lastObject != null ? _lastObject : firstSelect);
			GameStateManager.Instance.SetState(GameState.Interaction);
		}

		protected virtual void OpenSubMenu(IngameUIBase menuToOpen, GameObject source, bool nested = true)
		{
			canvas.gameObject.SetActive(false);
			_lastObject = source;
			menuToOpen.ShowMenu(nested ? this : null);
		}
	}

	public abstract class IngameUIBase<T> : IngameUIBase where T: new()
	{
		protected T Data { get; private set; }

		public bool ShowMenu(T data, IngameUIBase previous = null, Action onCloseCallback = null)
		{
			Data = data;
			var result = base.ShowMenu(previous, onCloseCallback);

			Populate(Data);
			return result;
		}

		protected abstract void Populate(T data);

	}
}