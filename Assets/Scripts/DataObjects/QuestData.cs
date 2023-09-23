using ExtensionClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using Quests.Generator;
using UnityEngine;
using Random = UnityEngine.Random;

namespace DataObjects 
{
	public enum QuestState
	{
		Inactive,
		Pending,
		Ongoing,
		Complete,
		Failed,
	}

	[Serializable]
	public class QuestData : BaseDataObject
	{
        
        [Header("Quest Details")]
        
        public string questLocation;


		public List<Guid> AdventurerIDs { get; set; } = new List<Guid>();

		[field:SerializeField]public QuestState State { get; set; }

		[field:SerializeField]public List<string> Rewards { get; set; }

		[field:SerializeField]public List<QuestStageData> Stages { get; set; } = new List<QuestStageData>();
		[field:SerializeField]public int? DayToActivate { get; set; }

		[field:SerializeField]public int? ActivateInDays { get; set; }
        public QuestData(QuestRandomizationData questRandomizationData)
		{

			questLocation = questRandomizationData.Name;

            var enemyType = questRandomizationData.EnemyTypes.RandomFromList();
			QuestDuration = enemyType.Durations.RandomFromList();
			var stages = (int)QuestDuration;
			for (int s = 0; s < stages; s++)
			{
				var newStage = new QuestStageData()
				{
					Order = (ushort)s,
					StageDifficulty = enemyType.Difficulties.RandomFromList(),

				};
				newStage.Setup();
				Stages.Add(newStage);
			}

            QuestReward = enemyType.Rewards.RandomFromList();
			QuestDifficulty = Stages.Max(data => data.StageDifficulty);
		}

		[field:SerializeField]public Reward QuestReward { get; set; }

		[field:SerializeField]public Duration QuestDuration { get; set; }

		[field:SerializeField]public Difficulty QuestDifficulty { get; set; }

		protected QuestData() { }
	}

	[Serializable]
	public class QuestStageData : BaseDataObject
	{
		public void Setup()
		{
			switch (StageDifficulty)
			{
				case Difficulty.Trivial: 
					SkillToBeat = Random.Range(5,11);
					FailureDamage = Random.Range(0, 4);
					break;
				case Difficulty.Easy: 
					SkillToBeat = Random.Range(1,10);
					FailureDamage = Random.Range(0, 4);
					break;
				case Difficulty.Medium: 
					SkillToBeat = Random.Range(5,20);
					FailureDamage = Random.Range(0, 4);
					break;
				case Difficulty.Hard:  
					SkillToBeat = Random.Range(8,30);
					FailureDamage = Random.Range(0, 4);
					break;
				case Difficulty.Extreme:  
					FailureDamage = Random.Range(10, 40);
					SkillToBeat = Random.Range(25,30);
					break;
			}

			TimeRemaining = TimeRequired;

		}
		[field:SerializeField]public ushort Order { get; set; }
		[field:SerializeField]public QuestState State { get; set; }
		[field:SerializeField]public string EnemyType { get; set; }
		[field:SerializeField]public string EnemyName { get; set; }
		[field:SerializeField]public int TimeRequired { get; set; } = 12;
		[field:SerializeField]public int TimeRemaining { get; set; }

		[field:SerializeField]public int SkillToBeat { get; set; }

		[field:SerializeField]public int CooldownTimer { get; set; } = 2;

		[field:SerializeField] public int FailureDamage { get; set; }
		[field:SerializeField]public bool? Passed { get; set; } = false;
		[field:SerializeField]public Difficulty StageDifficulty { get; set; }
	}
   


}