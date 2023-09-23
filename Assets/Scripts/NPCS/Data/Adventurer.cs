using System;
using DataObjects;
using NPCS;
using Unity.Collections;
using UnityEngine;

[Serializable]
public class Adventurer
{

	[field:SerializeField, ReadOnly] public AdventurerData AdventurerData { get; set; }
	[field:SerializeField, ReadOnly]public AdventurerAction AdventurerAction { get; set; }

	public Adventurer() { }
	public Adventurer(AdventurerData data) { AdventurerData = data; }

	public event Action<Adventurer, NPCState> ChangeStateEvent;

	public void Tick()
	{
		switch (AdventurerData.State)
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
		AdventurerData.State = newState;
		ChangeStateEvent?.Invoke(this, newState);
	}
}