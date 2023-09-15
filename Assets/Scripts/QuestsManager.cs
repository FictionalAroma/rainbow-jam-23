using System;
using DataObjects;
using Management;
using Management.Data;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class QuestsManager : MonoBehaviour
{
    WorldData theWorld;
    Quest questPrefab;
	private readonly List<QuestData> _completedQuests = new List<QuestData>();
	private readonly List<Quest> _activeQuests = new List<Quest>();
	private readonly List<QuestData> _inactiveQuests = new List<QuestData>();



	private void Start()
    {
		theWorld = WorldDataManager.Instance.TheWorld;
        TimeManager.Instance.OnTick += QuestOnTick;
		TimeManager.Instance.OnDayUpdate += QuestOnDay;

        List<QuestData> questsData = theWorld.QuestList;
	}

	private void QuestOnDay(int currentDay)
	{
		for (var index = _inactiveQuests.Count - 1; index >= 0; index--)
		{
			var inactive = _inactiveQuests[index];

			if (inactive.DayToActivate < currentDay || inactive.ActivateInDays <= 0)
			{
				_inactiveQuests.RemoveAt(index);
				_activeQuests.Add(new Quest(inactive));
			}
			else
			{
				inactive.ActivateInDays--;
			}
		}
	}

	private void QuestOnTick()
	{
		var completedThisTick = new List<Quest>(_activeQuests.Count);
		foreach (var activeQuest in _activeQuests)
		{
			activeQuest.Tick();
			if (activeQuest.IsComplete)
			{
				completedThisTick.Add(activeQuest);
			}
		}

		foreach (var completedQuest in completedThisTick)
		{
			_activeQuests.Remove(completedQuest);
			_completedQuests.Add(completedQuest.Data);
		}
		
	}

	private void PopulateQuests( List<QuestData> questsData)
    {
		foreach (var data in questsData)
		{
			switch (data.State)
			{
				case QuestState.Failed:
				case QuestState.Complete:
				{
					_completedQuests.Add(data);
					break;
				}
				case QuestState.Inactive:
				{
					_inactiveQuests.Add(data);
					break;
				}
				case QuestState.Pending:
				case QuestState.Ongoing:
				{
					var quest = new Quest(data);

					_activeQuests.Add(quest);
					break;
				}
				default: throw new ArgumentOutOfRangeException();
			}
		}
	}
}
