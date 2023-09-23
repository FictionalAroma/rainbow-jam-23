using System;
using DataObjects;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

namespace NPCS
{
    [Serializable]
	public class AdventurerData : NPCData
	{
		[field:SerializeField, ReadOnly] List<AdventurerAction> AdventurerActions { get; set; }
    }
}