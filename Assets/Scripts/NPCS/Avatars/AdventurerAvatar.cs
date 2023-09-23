using System;
using DataObjects;
using Interactions;
using UnityEngine;

namespace NPCS.Avatars
{ public class AdventurerAvatar : AdventurerInteraction
	{
		[SerializeField]
		Animator headAnimator;
		[SerializeField]
		Animator hairAnimator;
		[SerializeField]
		Animator bodyAnimator;
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

			itemName = Data.CharacterStats.firstName;
			
		}

		public void SetAnimators(AnimatorOverrideController getBody,
								 AnimatorOverrideController getHead,
								 AnimatorOverrideController getHair)
		{
			headAnimator.runtimeAnimatorController = getHead;
			bodyAnimator.runtimeAnimatorController = getBody;
			hairAnimator.runtimeAnimatorController = getHair;
		}
	}
}