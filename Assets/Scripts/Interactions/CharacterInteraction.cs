using CommonComponents;
using CommonComponents.Interfaces;
using GameMenu;
using UnityEngine;

namespace Interactions
{
	public abstract class CharacterInteraction<T> : CharacterInteraction where T:new()
	{
		private bool _canActivate = true;

		[SerializeField] protected IngameUIBase<T> menuToOpen;
		protected abstract T GetData();
		public override bool Action(InteractableActor interactableActor)
		{
			if (_canActivate)
			{
				menuToOpen.ShowMenu(GetData(), onCloseCallback:() => _canActivate = true);
				_canActivate = false;
			}

			return true;
		}
	}

	public abstract class CharacterInteraction : Interactable
	{
		public abstract void LinkUI(UIManager manager);
	}
}