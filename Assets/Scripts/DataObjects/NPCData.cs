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
	[Serializable]
	public class NPCData : BaseDataObject
	{
		public QuestSheet CharacterStats { get; set; }

		public NPCState State { get; set; } = NPCState.Idle;
		// status
		// action
		public bool IsAlive { get; set; } = true;
	}
}