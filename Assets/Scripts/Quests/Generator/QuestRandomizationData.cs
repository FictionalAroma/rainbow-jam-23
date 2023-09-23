using System.Collections.Generic;

namespace Quests.Generator
{
	public class QuestRandomizationDataJsonWrapper
	{
		public List<QuestRandomizationData> Locations { get; set; }
		
	}

	public class QuestRandomizationData 
	{
		public string Name { get; set; }
		public List<EnemyType> EnemyTypes { get; set; }
	
	}
	public class EnemyType
	{
		public string Typename { get; set; }
		public List<string> Names { get; set; }
		public List<Difficulty> Difficulties { get; set; }
		public List<Reward> Rewards { get; set; }
		public List<Duration> Durations { get; set; }
	}

	public enum Difficulty
	{

		Trivial = 1,
		Easy,
		Medium,
		Hard,
		Extreme
	}

	public enum Reward
	{
		Trash,
		Low,
		Standard,
		High,
		Bountiful
	}

	public enum Duration
	{
		VeryShort,
		Short,
		Medium,
		Long,
		Saga
	}

}