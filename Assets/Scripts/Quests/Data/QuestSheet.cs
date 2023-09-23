using System;
using ExtensionClasses;
using UnityEngine;

[Serializable]
//[CreateAssetMenu(fileName = "NewCharacter", menuName = "Character/New Character")]
public class QuestSheet
{
	[Header("Quest Details")]
	public string enemyType;
	public string questDuration;
	public string questReward;
	public string questLocation;
	

	public QuestSheet(QuestRandomizationData questRandomizationData)
	{
		enemyType = questRandomizationData.EnemyTypes.RandomFromList();
		questDuration =questRandomizationData.Durations.RandomFromList();
		questReward =questRandomizationData.Rewards.RandomFromList();
		questLocation = questRandomizationData.Locations.RandomFromList();

	}
}
