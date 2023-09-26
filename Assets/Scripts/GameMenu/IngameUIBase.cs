using System;
using CommonComponents.Interfaces;
using Management;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

namespace GameMenu
{
	public class IngameUIBase : MonoBehaviour
	{
		[SerializeField] protected Canvas canvas;

		private IngameUIBase _previousMenu;
		private EventSystem _eventSystem;
		private GameObject _lastObject;
		[SerializeField]private GameObject firstSelect;
		public SoundEffectGenerator SoundEffectGenerator { get; set; }

		private Action _onCloseCallback;

		public void Awake()
		{
			_eventSystem = EventSystem.current;
		}

		private void OnGUI()
		{
			switch (Event.current.type)
			{
				case EventType.KeyUp:
				{
					if (_eventSystem.currentSelectedGameObject.IsUnityNull())
					{
						_eventSystem.SetSelectedGameObject(firstSelect);
					}
					PlaySound();
					break;

				}
				case EventType.MouseDown:
					PlaySound();
					break;
			}
		}


		public virtual bool ShowMenu(IngameUIBase previous = null, Action onCloseCallback = null)
		{
			_onCloseCallback = onCloseCallback;
			_previousMenu = previous;
			ReturnFocus();
			PlaySound();
			return true;
		}


		public virtual void CloseMenu()
		{
			canvas.gameObject.SetActive(false);

			if (_previousMenu != null)
			{
				_previousMenu.ReturnFocus();
			}
			else
			{ 
				_onCloseCallback?.Invoke();
				GameStateManager.Instance.SetState(GameState.Running);
			}

			PlaySound();
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

		public void PlaySound()
		{
			if (SoundEffectGenerator != null)
			{
				SoundEffectGenerator.PlayRandomSound();
			}
		}
	}

	public abstract class IngameUIBase<T> : IngameUIBase where T: new()
	{
		protected T Data { get; set; }

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