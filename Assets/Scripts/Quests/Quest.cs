using System.Collections.Generic;
using System.Linq;
using DataObjects;
using NPCS;
using UnityEngine;

public class Quest
{
	private List<AdventurerData> _party;

	public QuestData Data { get; set; }
	public bool IsComplete => Data.State == QuestState.Complete;

    private QuestStageData _currentStageData;

	public Quest(QuestData questdata)
	{
		Data = questdata;
		Data.Stages = Data.Stages.OrderBy(stage => stage.Order).ToList();
	}

	public void Tick()
	{
		_currentStageData.TimeRemaining--;
		if (_currentStageData.TimeRemaining < 0)
		{
			if (DoStageTest(_currentStageData))
			{
				_currentStageData.State = QuestState.Complete;
				UpdateCurrentStage();
				if (_currentStageData == null)
				{
					this.Data.State = QuestState.Complete;
				}

			}
		}
	}

	private bool DoStageTest(QuestStageData currentStageData)
	{
		var current = currentStageData.Obstacles.FirstOrDefault(data => !data.Passed.HasValue);
		if (current != null)
		{
			if (DoSkillCheck(current))
			{
				current.Passed = true;
			}
			else
			{
				current.Passed = false;
				//do adventer damage here
			}
		}

		return currentStageData.Obstacles.All(data => data.Passed.HasValue);

	}

	private bool DoSkillCheck(QuestObstacleData current)
	{
		return Random.Range(0, 100) < current.SkillToBeat;
	}

	public void UpdateCurrentStage()
	{
		_currentStageData = Data.Stages.FirstOrDefault(stage => stage.State == QuestState.Pending);
	}
}
