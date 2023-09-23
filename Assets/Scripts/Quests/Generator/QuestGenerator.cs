using DataObjects;
using ExtensionClasses;
using NPCS;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Quests.Generator;
using UnityEngine;

public class QuestGenerator
{
    private List<QuestRandomizationData> _locations;

    public QuestGenerator(string filePath)
    {
        ImportRandomizationData(filePath);
    }

    public void ImportRandomizationData(string filePath)
    {
        var wrapper = JsonUtils.LoadFromFile<QuestRandomizationDataJsonWrapper>(filePath);
		_locations = wrapper.Locations;
	}

    // Update is called once per frame
    public Quest GenerateQuest()
    {
        if (!_locations.Any())
        {
            return null;
        }


		var questRandomizationData = _locations.RandomFromList();

        //for integers
        //var intData = JsonUtility.FromJson<int>(jsonDB.text);
        // Deserialize the JSON data into a Dictionary<string, string[]>
        //var stringData = JsonConvert.DeserializeObject<Dictionary<string, string[]>>(json);

        // Populate UI fields


        return new Quest(questRandomizationData);

    }

    /*public AdventurerData GenerateAdventurer()
    {
        var characterSheet = GenerateCharacter();
        var newAdventurer = new AdventurerData() { CharacterStats = characterSheet };

        return newAdventurer;
    }*/


}
