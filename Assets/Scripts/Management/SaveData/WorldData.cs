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
		public List<AdventurerData> AdventurerList { get; set; }
		public List<QuestData> QuestList { get; set; }

		public PlayerData Player { get; set; }
	}
}