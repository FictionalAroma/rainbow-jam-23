using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class QuestRandomizationDataJsonWrapper
{
    public Dictionary<string,QuestRandomizationData> Locations { get; set; }
    
    
}

public class QuestRandomizationData 
{


    
    public List<EnemyType> enemyTypes { get; set; }
    
    
   
    
}
public class EnemyType
{
    public string typename { get; set; }
    public List<string> names { get; set; }
    public List<string> Difficulties { get; set; }
    public List<string> Rewards { get; set; }
    public List<string> Durations { get; set; }
}



