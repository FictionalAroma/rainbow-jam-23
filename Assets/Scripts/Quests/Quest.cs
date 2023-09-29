using System;
using System.Collections.Generic;
using System.Linq;
using DataObjects;
using JetBrains.Annotations;
using NPCS;
using Quests.Generator;
using UnityEngine;
using Random = UnityEngine.Random;

[Serializable]
public class Quest : QuestData
{
	private List<AdventurerData> _party;

	public bool IsComplete => this.State == QuestState.Complete;

	[field:SerializeField] private QuestStageData _currentStageData;

	[UsedImplicitly]
	public Quest() { }
	public Quest(QuestRandomizationData questRandomizationData) : base(questRandomizationData) { }


	public void Tick()
	{
		_currentStageData.TimeRemaining--;
		TimeRemaining--;
		if (_currentStageData.TimeRemaining < 0)
		{
			if (DoStageTest(_currentStageData))
			{
				_currentStageData.State = QuestState.Complete;
				UpdateCurrentStage();
				if (_currentStageData == null)
				{
					this.State = QuestState.Complete;
				}

			}
		}
	}

	private bool DoStageTest(QuestStageData currentStageData)
	{
		var result = DoSkillCheck(currentStageData.SkillToBeat);
		currentStageData.Passed = result;
		//do adventer damage here
		return result;
	}

	private bool DoSkillCheck(int skillToBeat)
	{
		return Random.Range(0, 100) < skillToBeat;
	}

	public void UpdateCurrentStage()
	{
		_currentStageData = this.Stages.FirstOrDefault(stage => stage.State == QuestState.Pending);
	}
}
