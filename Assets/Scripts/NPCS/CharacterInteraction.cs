using System;
using CommonComponents;
using CommonComponents.Interfaces;
using GameMenu;
using UnityEngine;

namespace NPCS
{
	public class CharacterInteraction : Interactable
	{
		private bool _canActivate = true;

		[SerializeField] private IngameUIBase<CharacterSheet> menuToOpen;
		[SerializeField] private CharacterSheet stats;

		public override bool Action(InteractableActor interactableActor)
		{

			if (_canActivate)
			{
				menuToOpen.ShowMenu(stats, onCloseCallback:() => _canActivate = true);
				_canActivate = false;
			}

			return true;
		}
	}
}