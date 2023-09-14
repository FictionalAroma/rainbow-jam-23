using Newtonsoft.Json;
using System.Collections.Generic;
using Extensions;
using UnityEngine;

public class NPCGenerator : MonoBehaviour
{
    
    [SerializeField] TextAsset jsonDB;
    [SerializeField] int num_of_neg_traits,num_of_pos_traits, num_of_flaws, num_of_ideals, num_of_skills;
    [SerializeField] bool generateCharacter = false;

	private List<CharacterRandomizationData> _characterGenList;

    void Start()
    {
		var wrapper = JsonConvert.DeserializeObject<CharacterRandomizationDataJsonWrapper>(jsonDB.text);
		_characterGenList = wrapper.NPCList;
	}

    // Update is called once per frame
    void Update()
    {
        if (generateCharacter)
        {
            var character = GenerateCharacter(_characterGenList);
            Debug.Log(character.firstName);
            Debug.Log(character.lastName);
        }
    }
    public CharacterSheet GenerateCharacter(List<CharacterRandomizationData> jsonDB)
    {
        generateCharacter = false;
        if (jsonDB == null)
        {
            return null;
        }

		CharacterSheet characterSheet = ScriptableObject.CreateInstance<CharacterSheet>();

		var randomData = Random.Range(0, _characterGenList.Count);
		var characterRandomizationData = _characterGenList[randomData];
		//for integers
		//var intData = JsonUtility.FromJson<int>(jsonDB.text);
		// Deserialize the JSON data into a Dictionary<string, string[]>
		//var stringData = JsonConvert.DeserializeObject<Dictionary<string, string[]>>(json);

		// Populate UI fields
		characterSheet.firstName = characterRandomizationData.FirstNames.RandomFromList();
		characterSheet.lastName = characterRandomizationData.Surnames.RandomFromList();
		characterSheet.level = characterRandomizationData.Level.GetRandomValue;//RandomIntFromArray(intData["level"]);
		characterSheet.npcClass = characterRandomizationData.Class.RandomFromList();
		characterSheet.race = characterRandomizationData.Race.RandomFromList();;
		characterSheet.strength = characterRandomizationData.Strength.GetRandomValue;
		characterSheet.dexterity = characterRandomizationData.Dexterity.GetRandomValue;
		characterSheet.constitution = characterRandomizationData.Constitution.GetRandomValue;
		characterSheet.intelligence = characterRandomizationData.Intelligence.GetRandomValue;
		characterSheet.wisdom = characterRandomizationData.Wisdom.GetRandomValue;
		characterSheet.charisma = characterRandomizationData.Charisma.GetRandomValue;
		characterSheet.pos_traits = characterRandomizationData.TraitsPos.RandomFromList(num_of_pos_traits);
		characterSheet.neg_traits= characterRandomizationData.TraitsNeg.RandomFromList(num_of_neg_traits);
		characterSheet.flaws = characterRandomizationData.Flaws.RandomFromList(num_of_flaws);
		characterSheet.ideals = characterRandomizationData.Ideals.RandomFromList(num_of_ideals);
		characterSheet.skills = characterRandomizationData.Skills.RandomFromList(num_of_skills);
                
		
		return characterSheet;

    }

}
