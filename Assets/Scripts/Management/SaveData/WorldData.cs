using System;
using System.Collections.Generic;
using DataObjects;
using NPCS;

namespace Management.Data
{
	[Serializable]
	public class WorldData
	{
		public int Day { get; set; }
		public int TimeOfDay { get; set; }
		public List<AdventurerData> AdventurerList { get; set; } = new List<AdventurerData>();
		public List<QuestData> QuestList { get; set; } = new List<QuestData>();

		public PlayerData Player { get; set; }
	}
}