using System;

namespace DataObjects
{
	public enum NPCState
	{
		Idle,
		Quest,
		Busy,
		Dead
	}
	public class NPCData : BaseDataObject
	{
		public CharacterSheet CharacterStats { get; set; }

		public NPCState State { get; set; }
		// status
		// action
		public bool IsAlive { get; set; }
	}
}