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
    [SerializeField] int num_of_traits, num_of_flaws, num_of_ideals, num_of_skills;
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
                //for integers
                var intData = JsonUtility.FromJson<int>(jsonDB.text);
                // Deserialize the JSON data into a Dictionary<string, string[]>
                var stringData = JsonConvert.DeserializeObject<Dictionary<string, string[]>>(json);

                // Populate UI fields
                characterSheet.firstName = RandomStringFromArray(stringData["fname"]);
                characterSheet.lastName = RandomStringFromArray(stringData["lname"]);
                characterSheet.level = intData["level"];//RandomIntFromArray(intData["level"]);
                characterSheet.npcClass = RandomIntFromArray(stringData["class"]);
                characterSheet.race = RandomStringFromArray(stringData["race"]);
                characterSheet.strength = RandomIntFromArray(data["strength"]);
                characterSheet.dexterity = RandomIntFromArray(data["dexterity"]);
                characterSheet.constitution = RandomIntFromArray(data["constitution"]);
                characterSheet.intelligence = RandomIntFromArray(data["intelligence"]);
                characterSheet.wisdom = RandomIntFromArray(data["wisdom"]);
                characterSheet.charisma = RandomIntFromArray(data["charisma"]);
                characterSheet.healthPoints = RandomIntFromArray(data["hp"]);
                characterSheet.healthPointsMax = RandomIntFromArray(data["hp"]); // For simplicity, using the same value for max HP
                characterSheet.armorClass = RandomIntFromArray(data["ac"]);
                characterSheet.traits = ReturnMultipleRandomStringsFromArray(stringData["traits"],num_of_traits);
                characterSheet.flaws = ReturnMultipleRandomStringsFromArray(stringData["flaws"],num_of_flaws);
                characterSheet.ideals = ReturnMultipleRandomStringsFromArray(stringData["ideals"],num_of_ideals);
                characterSheet.skills = ReturnMultipleRandomStringsFromArray(stringData["skills"],num_of_skills);
                
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
