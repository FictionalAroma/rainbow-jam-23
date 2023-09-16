﻿using System;
using UnityEngine;

namespace DataObjects
{
	public enum NPCState
	{
		None,
		Idle,
		Quest,
		Busy,
		Dead
	}
	[Serializable]
	public class NPCData : BaseDataObject
	{
		[field:SerializeField]public CharacterSheet CharacterStats { get; set; }

		[field:SerializeField]public NPCState State { get; set; } = NPCState.None;
		// status
		// action
		[field:SerializeField]public bool IsAlive { get; set; } = true;
	}
}