using DataObjects;
using Management;
using Management.Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestsManager : MonoBehaviour
{
    WorldData theWorld;
    Quest questPrefab;
    private void Awake()
    {
        theWorld = WorldDataManager.Instance.TheWorld;
    }
    private void Start()
    {
        List<QuestData> questsData = theWorld.QuestList;
    }
    private void PopulateQuests( List<QuestData> questsData)
    {
        List<Quest> quests = new List<Quest>();
        foreach (QuestData questdata in questsData)
        {
            var newQuest = Instantiate(questPrefab);
            newQuest.Populate(questdata);
            quests.Add(newQuest);
        }
    }
}
