using ExtensionClasses;
using NPCS;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class QuestGenerator
{
    private List<QuestRandomizationData> _questGenList;

    public QuestGenerator(string filePath)
    {
        _questGenList = new List<QuestRandomizationData>();
        ImportRandomizationData(filePath);
    }

    public void ImportRandomizationData(string filePath)
    {
        var wrapper = JsonUtils.LoadFromFile<QuestRandomizationDataJsonWrapper>(filePath);
        _questGenList.AddRange(wrapper.QuestList);
    }

    // Update is called once per frame
    public QuestSheet GenerateQuest()
    {
        if (!_questGenList.Any())
        {
            return null;
        }
        var randomData = Random.Range(0, _questGenList.Count);
        var questRandomizationData = _questGenList[randomData];

        QuestSheet QuestSheet = new QuestSheet(questRandomizationData);

        //for integers
        //var intData = JsonUtility.FromJson<int>(jsonDB.text);
        // Deserialize the JSON data into a Dictionary<string, string[]>
        //var stringData = JsonConvert.DeserializeObject<Dictionary<string, string[]>>(json);

        // Populate UI fields


        return QuestSheet;

    }

    /*public AdventurerData GenerateAdventurer()
    {
        var characterSheet = GenerateCharacter();
        var newAdventurer = new AdventurerData() { CharacterStats = characterSheet };

        return newAdventurer;
    }*/


}
