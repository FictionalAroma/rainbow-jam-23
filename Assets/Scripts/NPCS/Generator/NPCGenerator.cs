using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using ExtensionClasses;
using UnityEngine;

public class NPCGenerator
{
    
    [SerializeField] TextAsset jsonDB;

	private List<CharacterRandomizationData> _characterGenList;

	public NPCGenerator(string filePath)
    {
        _characterGenList = new List<CharacterRandomizationData>();
        ImportRandomizationData(filePath);
    }

    public void ImportRandomizationData(string filePath)
    {
        var wrapper = JsonConvert.DeserializeObject<CharacterRandomizationDataJsonWrapper>(filePath);
        _characterGenList.AddRange(wrapper.NPCList);
    }

    // Update is called once per frame
    public CharacterSheet GenerateCharacter()
    {
        if (jsonDB == null || !_characterGenList.Any())
        {
            return null;
        }
		var randomData = Random.Range(0, _characterGenList.Count);
		var characterRandomizationData = _characterGenList[randomData];

		CharacterSheet characterSheet = new CharacterSheet(characterRandomizationData);

		//for integers
		//var intData = JsonUtility.FromJson<int>(jsonDB.text);
		// Deserialize the JSON data into a Dictionary<string, string[]>
		//var stringData = JsonConvert.DeserializeObject<Dictionary<string, string[]>>(json);

		// Populate UI fields
                
		
		return characterSheet;

    }

}
