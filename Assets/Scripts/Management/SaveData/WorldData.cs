using System;
using System.Collections.Generic;
using DataObjects;

namespace Management.Data
{
	[Serializable]
	public class WorldData
	{
		public int Day { get; set; }
		public int TimeOfDay { get; set; }
		public List<NPCData> AdventurerList { get; set; }
		public List<QuestData> QuestList { get; set; }

		public PlayerData Player { get; set; }
	}
}