using SuperTiled2Unity;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
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
            GenerateCharacter(jsonDB);
        }
    }
    public CharacterSheet GenerateCharacter(TextAsset jsonDB)
    {
        generateCharacter = false;
        CharacterSheet characterSheet = new CharacterSheet();
        if (jsonDB == null)
        {
            return null;
        }
        else
        {
            
            string json = jsonDB.text;
            if (!string.IsNullOrEmpty(json))
            {
                // Deserialize the JSON data into a Dictionary<string, string[]>
                var data = JsonUtility.FromJson<Dictionary<string, string[]>>(json);

                // Populate UI fields
                characterSheet.firstName = RandomFromArray(data["fname"]);
                characterSheet.lastName = RandomFromArray(data["lname"]);
                characterSheet.level = RandomFromArray(data["level"]).ToInt();
                characterSheet.npcClass = RandomFromArray(data["npcClass"]);
                characterSheet.race = RandomFromArray(data["race"]);
                characterSheet.strength = RandomFromArray(data["strength"]).ToInt();
                characterSheet.dexterity = RandomFromArray(data["dexterity"]).ToInt();
                characterSheet.constitution = RandomFromArray(data["constitution"]).ToInt();
                characterSheet.intelligence = RandomFromArray(data["intelligence"]).ToInt();
                characterSheet.wisdom = RandomFromArray(data["wisdom"]).ToInt();
                characterSheet.charisma = RandomFromArray(data["charisma"]).ToInt();
                characterSheet.healthPoints = RandomFromArray(data["hp"]).ToInt();
                characterSheet.healthPointsMax = RandomFromArray(data["hp"]).ToInt(); // For simplicity, using the same value for max HP
                characterSheet.armorClass = RandomFromArray(data["ac"]).ToInt();
                characterSheet.traits = ReturnMultipleRandomFromArray(data["traits"],num_of_traits);
                characterSheet.flaws = ReturnMultipleRandomFromArray(data["flaws"],num_of_flaws);
                characterSheet.ideals = ReturnMultipleRandomFromArray(data["ideals"],num_of_ideals);
                characterSheet.skills = ReturnMultipleRandomFromArray(data["skills"],num_of_skills);
                
            }
        }
        return characterSheet;

    }
    private string[] ReturnMultipleRandomFromArray(string[] array, int sizeOfArrayToReturn)
    {
        List<string> listToReturn = new List<string>();
        for (int i = 0; i< sizeOfArrayToReturn; i++)
        {
            listToReturn.Add(RandomFromArray(array));
        }
        return listToReturn.ToArray();
    }
    private string RandomFromArray(string[] array)
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
}
