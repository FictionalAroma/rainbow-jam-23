using System;
using DataObjects;
using NPCS;
using Unity.Collections;
using UnityEngine;

[Serializable]
public class Adventurer : AdventurerData
{

	[field:SerializeField, ReadOnly]public AdventurerAction AdventurerAction { get; set; }

	public event Action<Adventurer, NPCState> ChangeStateEvent;

	public void Tick()
	{
		switch (State)
		{
			case NPCState.None:
			{
				if (AdventurerAction?.TicksLeft < 0)
				{
					ChangeState(NPCState.Busy);
					break;
				}
				ChangeState(NPCState.Idle);
				break;
			}
			case NPCState.Busy:
				AdventurerAction.TicksLeft--;
				if (AdventurerAction.TicksLeft <= 0)
				{
					ChangeState(NPCState.Idle);
				}

				break;
			default: break;
		}
	}

	private void ChangeState(NPCState newState)
	{
		State = newState;
		ChangeStateEvent?.Invoke(this, newState);
	}
}