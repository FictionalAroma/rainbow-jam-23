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

	public void Tick()
	{
		switch (AdventurerData.State)
		{
			case NPCState.Busy:
				AdventurerAction.TicksLeft--;
				if (AdventurerAction.TicksLeft <= 0)
				{
					AdventurerData.State = NPCState.Idle;
				}

				break;
			default: break;
		}
	}
}