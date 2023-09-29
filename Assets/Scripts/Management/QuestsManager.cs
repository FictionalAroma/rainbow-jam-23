using System;
using DataObjects;
using Management;
using Management.Data;
using System.Collections.Generic;
using UnityEngine;

public class QuestsManager : MonoSingleton<QuestsManager>
{
    WorldData theWorld;
	private List<QuestData> _completedQuests = new List<QuestData>();
	[SerializeField] private List<Quest> _activeQuests = new List<Quest>();
	private List<QuestData> _inactiveQuests = new List<QuestData>();

	public List<Quest> ActiveQuests => _activeQuests;

	public event Action<Quest> NewQuest;


	protected void Start() 
	{ 
		theWorld = WorldDataManager.Instance.TheWorld;
        TimeManager.Instance.OnTick += QuestOnTick;
		TimeManager.Instance.OnDayUpdate += QuestOnDay;
		PopulateQuests(theWorld.QuestList);
	}

	private void OnDestroy()
	{
		TimeManager.Instance.OnTick -= QuestOnTick;
		TimeManager.Instance.OnDayUpdate -= QuestOnDay;
	}

	private void QuestOnDay(int currentDay)
	{
		for (var index = _inactiveQuests.Count - 1; index >= 0; index--)
		{
			var inactive = _inactiveQuests[index];

			if (inactive.DayToActivate < currentDay || inactive.ActivateInDays <= 0)
			{
				_inactiveQuests.RemoveAt(index);
				ActiveQuests.Add((Quest)inactive);
			}
			else
			{
				inactive.ActivateInDays--;
			}
		}
	}

	private void QuestOnTick()
	{
		var completedThisTick = new List<Quest>(ActiveQuests.Count);
		foreach (var activeQuest in ActiveQuests)
		{
			activeQuest.Tick();
			if (activeQuest.IsComplete)
			{
				completedThisTick.Add(activeQuest);
			}
		}

		foreach (var completedQuest in completedThisTick)
		{
			ActiveQuests.Remove(completedQuest);
			_completedQuests.Add(completedQuest);
		}
		
	}

	private void PopulateQuests( List<Quest> questsData)
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
					ActiveQuests.Add(data);
					break;
				}
				default: throw new ArgumentOutOfRangeException();
			}
		}
	}

	public void AddNewQuest()
	{
		var quest = WorldDataManager.Instance.GenerateQuest();
		ActiveQuests.Add(quest);
		NewQuest?.Invoke(quest);
	}
}
