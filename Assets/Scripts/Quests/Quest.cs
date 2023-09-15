using DataObjects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : MonoBehaviour
{
    public void PopulateQuest(QuestData questData)
    {
        public enum QuestState
    {
        Inactive,
        Pending,
        Ongoing,
        Complete,
        Failed,
    }
        public List<Guid> AdventurerIDs { get; set; }

        public QuestState State { get; set; }

        public List<string> Rewards { get; set; }

        public List<QuestStageData> Stages { get; set; }

        public string Reward { get; set; }
    

    public class QuestStageData : BaseDataObject
    {
        public QuestState State { get; set; }

        public int TimeRequired { get; set; }
        public int TimeRemaining { get; set; }

        public List<QuestObstacleData> Obstacles { get; set; }
    }

    public class QuestObstacleData : BaseDataObject
    {
        public int SkillToBeat { get; set; }

        public int CooldownTimer { get; set; }

        public int FailureDamage { get; set; }
    }
}
}
