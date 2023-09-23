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

		[SerializeField] private IngameUIBase<QuestSheet> menuToOpen;
		[SerializeField] private QuestSheet stats;

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