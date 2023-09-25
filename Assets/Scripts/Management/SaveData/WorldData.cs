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
		public List<Adventurer> AdventurerList { get; set; } = new List<Adventurer>();
		public List<Quest> QuestList { get; set; } = new List<Quest>();

		public PlayerData Player { get; set; }
	}
}