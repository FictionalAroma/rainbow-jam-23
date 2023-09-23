using System.Collections.Generic;
using System.Linq;
using ExtensionClasses;
using NPCS.Generator;
using UnityEngine;

public class NPCGenerator
{
	private CharacterRandomizationDataJsonWrapper _dataWrapper;

	public NPCGenerator(string filePath)
    {
        ImportRandomizationData(filePath);
    }

    public void ImportRandomizationData(string filePath)
    {
		_dataWrapper = JsonUtils.LoadFromFile<CharacterRandomizationDataJsonWrapper>(filePath);
    }

    // Update is called once per frame
    public CharacterSheet GenerateCharacter()
    {
        if (!_dataWrapper.NPCList.Any() || !_dataWrapper.Races.Any())
        {
            return null;
        }
		var randomData = Random.Range(0, _dataWrapper.NPCList.Count);
		var characterRandomizationData = _dataWrapper.NPCList[randomData];

		CharacterSheet characterSheet = new CharacterSheet(characterRandomizationData);
		//for integers
		//var intData = JsonUtility.FromJson<int>(jsonDB.text);
		// Deserialize the JSON data into a Dictionary<string, string[]>
		//var stringData = JsonConvert.DeserializeObject<Dictionary<string, string[]>>(json);

		// Populate UI fields
                
		
		return characterSheet;

    }

	public Adventurer GenerateAdventurer() { 		
		var characterSheet = GenerateCharacter();
		
		if (!_dataWrapper.Races.TryGetValue(characterSheet.race, out var foundData))
		{
			foundData = _dataWrapper.Races.First().Value;
		}

		characterSheet.AddVisual(foundData);

		var newAdventurer = new Adventurer { CharacterStats = characterSheet };

		return newAdventurer;
	}
}
