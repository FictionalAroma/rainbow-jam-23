using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class QuestRandomizationDataJsonWrapper
{
    public List<QuestRandomizationData> QuestList { get; set; }
}

public class QuestRandomizationData 
{

    public List<string> Locations { get; set; }
    public List<string> EnemyTypes { get; set; }
    
    public List<string> EnemyNames { get; set; }
    public List<string> Difficulties { get; set; }
    public List<string> Rewards { get; set; }
    public List<string> Durations { get; set; }
    
}

public class QuestStatRandomizationData
{
    public int Min { get; set; }
    public int Max { get; set; }
    public int GetRandomValue => Random.Range(Min, Max + 1);
}
}
