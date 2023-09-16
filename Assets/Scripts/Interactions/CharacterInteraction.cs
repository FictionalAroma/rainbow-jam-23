using CommonComponents;
using CommonComponents.Interfaces;
using GameMenu;
using UnityEngine;

namespace Interactions
{
	public abstract class CharacterInteraction<T> : Interactable where T:new()
	{
		private bool _canActivate = true;

		[SerializeField] private IngameUIBase<T> menuToOpen;
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
}