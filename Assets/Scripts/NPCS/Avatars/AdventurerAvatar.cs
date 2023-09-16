using System;
using DataObjects;
using Interactions;
using UnityEngine;

namespace NPCS.Avatars
{
	[RequireComponent(typeof(SpriteRenderer))]
	public class AdventurerAvatar : AdventurerInteraction
	{

		private void Start()
		{
			Data.ChangeStateEvent += OnChangeStateEvent;
		}

		private void OnChangeStateEvent(Adventurer adv, NPCState state)
		{
			if (state != NPCState.Idle)
			{
				Destroy(this, 1f);
			}
		}

		private void OnDestroy()
		{
			Data.ChangeStateEvent -= OnChangeStateEvent;
		}

		public void Setup(Adventurer npc, UIManager uiChache)
		{
			Data = npc;
			if (TryGetComponent<CharacterInteraction>(out var interaction))
			{
				interaction.LinkUI(uiChache);
			}

			itemName = Data.AdventurerData.CharacterStats.firstName;
		}
	}
}