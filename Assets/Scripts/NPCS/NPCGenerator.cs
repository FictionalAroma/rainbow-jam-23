using Microsoft.Unity.VisualStudio.Editor;
using Newtonsoft.Json;
using SuperTiled2Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager.UI;
using UnityEngine;
using static Cinemachine.DocumentationSortingAttribute;
using static UnityEngine.ParticleSystem;

public class NPCGenerator : MonoBehaviour
{
    
    [SerializeField] TextAsset jsonDB;
    [SerializeField] int num_of_neg_traits,num_of_pos_traits, num_of_flaws, num_of_ideals, num_of_skills;
    [SerializeField] bool generateCharacter = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (generateCharacter)
        {
            var character = GenerateCharacter(jsonDB);
            Debug.Log(character.firstName);
            Debug.Log(character.lastName);
        }
    }
    public CharacterSheet GenerateCharacter(TextAsset jsonDB)
    {
        generateCharacter = false;
        CharacterSheet characterSheet = ScriptableObject.CreateInstance<CharacterSheet>();
        if (jsonDB == null)
        {
            return null;
        }
        else
        {
            
            string json = jsonDB.text;
            if (!string.IsNullOrEmpty(json))
            {
                CharacterAttributesFromJson characterAttributesFromJson = JsonUtility.FromJson<CharacterAttributesFromJson>(json);
                Debug.Log(characterAttributesFromJson.surnames);
                //for integers
                //var intData = JsonUtility.FromJson<int>(jsonDB.text);
                // Deserialize the JSON data into a Dictionary<string, string[]>
                //var stringData = JsonConvert.DeserializeObject<Dictionary<string, string[]>>(json);

                // Populate UI fields
                characterSheet.firstName = RandomStringFromArray(characterAttributesFromJson.first_names.ToArray());
                characterSheet.lastName = RandomStringFromArray(characterAttributesFromJson.surnames.ToArray());
                characterSheet.level = characterAttributesFromJson.level;//RandomIntFromArray(intData["level"]);
                characterSheet.npcClass = RandomStringFromArray(characterAttributesFromJson.@class.ToArray());
                characterSheet.race = RandomStringFromArray(characterAttributesFromJson.race.ToArray());
                characterSheet.strength = characterAttributesFromJson.strength;
                characterSheet.dexterity = characterAttributesFromJson.dexterity;
                characterSheet.constitution = characterAttributesFromJson.constitution;
                characterSheet.intelligence = characterAttributesFromJson.intelligence;
                characterSheet.wisdom = characterAttributesFromJson.wisdom;
                characterSheet.charisma = characterAttributesFromJson.charisma;
                characterSheet.pos_traits = ReturnMultipleRandomStringsFromArray(characterAttributesFromJson.traitsPos.ToArray(),num_of_pos_traits);
                characterSheet.neg_traits= ReturnMultipleRandomStringsFromArray(characterAttributesFromJson.traitsNeg.ToArray(),num_of_neg_traits);
                characterSheet.flaws = ReturnMultipleRandomStringsFromArray(characterAttributesFromJson.flaws.ToArray(),num_of_flaws);
                characterSheet.ideals = ReturnMultipleRandomStringsFromArray(characterAttributesFromJson.ideals.ToArray(),num_of_ideals);
                characterSheet.skills = ReturnMultipleRandomStringsFromArray(characterAttributesFromJson.skills.ToArray(),num_of_skills);
                
            }
        }
        return characterSheet;

    }
    private string[] ReturnMultipleRandomStringsFromArray(string[] array, int sizeOfArrayToReturn)
    {
        List<string> listToReturn = new List<string>();
        for (int i = 0; i< sizeOfArrayToReturn; i++)
        {
            listToReturn.Add(RandomStringFromArray(array));
        }
        return listToReturn.ToArray();
    }
    private string RandomStringFromArray(string[] array)
    {
        if (array.Length > 0)
        {
            int randomIndex = Random.Range(0, array.Length);
            return array[randomIndex];
        }
        else
        {
            return array[0];
        }


    }
    private int RandomIntFromArray(int[] array)
    {
        if (array.Length > 0)
        {
            int randomIndex = Random.Range(0,array.Length);
            return array[randomIndex];
        }
        else
        {
            return array[0];
        }
    }
}
