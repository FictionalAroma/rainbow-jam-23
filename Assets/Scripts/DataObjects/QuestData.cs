using ExtensionClasses;
using System;
using System.Collections.Generic;
using UnityEngine;

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

	public class QuestData : BaseDataObject
	{
        
        [Header("Quest Details")]
        
        public string questLocation;

       
        public List<Guid> AdventurerIDs { get; set; }

		public QuestState State { get; set; }

		public List<string> Rewards { get; set; }

		public List<QuestStageData> Stages { get; set; }
		public int? DayToActivate { get; set; }

		public int? ActivateInDays { get; set; }
        public QuestData(QuestRandomizationData questRandomizationData)
        {
            enemyType = questRandomizationData.EnemyTypes.RandomFromList();
            questDuration = questRandomizationData.Durations.RandomFromList();
            questReward = questRandomizationData.Rewards.RandomFromList();
            questLocation = questRandomizationData.Locations.RandomFromList();

        }
    }

	public class QuestStageData : BaseDataObject
	{
		public ushort Order { get; set; }
		public QuestState State { get; set; }
        public string enemyType;
        public string enemyName;
        public int TimeRequired { get; set; }
		public int TimeRemaining { get; set; }

        public int SkillToBeat { get; set; }

        public int CooldownTimer { get; set; }

        public int FailureDamage { get; set; }
        public bool? Passed { get; set; }

        

	}
   


}