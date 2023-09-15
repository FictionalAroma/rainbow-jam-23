using System;
using DataObjects;
using System.Collections.Generic;
using UnityEngine;

namespace NPCS
{
    [Serializable]
	public class AdventurerData : NPCData
	{
        List<AdventurerAction> AdventurerActions { get; set; }
    }
}