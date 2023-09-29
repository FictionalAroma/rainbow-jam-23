using System;
using System.Collections.Generic;
using DataObjects;
using ExtensionClasses;
using Interactions;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

namespace NPCS.Avatars
{ public class AdventurerAvatar : AdventurerInteraction
	{
		[SerializeField]
		AvatarPart headAnimator;
		[SerializeField]
		AvatarPart hairAnimator;
		[SerializeField]
		AvatarPart bodyAnimator;

		private List<Transform> _navPositions;
		private float _nextWanderTime = -1f;
		[SerializeField] private NavMeshAgent navAgent;
		private bool _arrivedAtPoint;

		private void Start()
		{
			Data.ChangeStateEvent += OnChangeStateEvent;
			navAgent.updateUpAxis = false;
			navAgent.updateRotation = false;
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

		public void Update()
		{
			if (!_arrivedAtPoint && navAgent.remainingDistance < float.Epsilon)
			{
				_arrivedAtPoint = true;
			}
			else
			{
				if (_nextWanderTime < 0f)
				{
					WanderToRandomPoint();
				}
				else
				{
					_nextWanderTime -= Time.deltaTime;
					UpdatePartVelocity(navAgent.velocity);

				}
			}

		}

		private void WanderToRandomPoint()
		{
			var point = _navPositions.RandomFromList();
			navAgent.SetDestination(point.position);
			_nextWanderTime = Random.Range(10f, 30f);
			_arrivedAtPoint = false;
		}

		public void Setup(Adventurer npc, UIManager uiChache, List<Transform> navigationPositions)
		{
			Data = npc;
			if (TryGetComponent<CharacterInteraction>(out var interaction))
			{
				interaction.LinkUI(uiChache);
			}

			itemName = Data.CharacterStats.firstName;

			_navPositions = navigationPositions;
			WanderToRandomPoint();
		}

		public void SetAnimators(AnimatorOverrideController getBody,
								 AnimatorOverrideController getHead,
								 AnimatorOverrideController getHair)
		{
			headAnimator.SetRuntimeAnimation(getHead);
			bodyAnimator.SetRuntimeAnimation(getBody);
			hairAnimator.SetRuntimeAnimation(getHair);
		}

		public void UpdatePartVelocity(Vector2 velocity)
		{
			var velNorm = velocity.normalized;
			headAnimator.UpdateVelocity(velNorm);
			bodyAnimator.UpdateVelocity(velNorm);
			hairAnimator.UpdateVelocity(velNorm);
		}
	}
}