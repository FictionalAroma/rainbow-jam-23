using UnityEngine;

[CreateAssetMenu(fileName = "NewCharacter", menuName = "Character/New Character")]
public class CharacterSheet : ScriptableObject
{
	
	[Header("Character Details")]
	[SerializeField] public string firstName;
	[SerializeField] public string lastName;
	[SerializeField] public string race;

	[Header("Character Class")]
	[SerializeField] public int level;
	[SerializeField] public string npcClass;
	[SerializeField] public string[] skills;

	
	[Header("Stats")]
	[SerializeField] public int healthPoints;
	[SerializeField] public int healthPointsMax;
	[SerializeField] public int armorClass;
	[SerializeField] public int strength;
	[SerializeField] public int dexterity;
	[SerializeField] public int constitution;
	[SerializeField] public int intelligence;
	[SerializeField] public int wisdom;
	[SerializeField] public int charisma;

	
	[Header("Personality")]
	[SerializeField] public string[] traits;
	[SerializeField] public string[] flaws;
	[SerializeField] public string[] ideals;

}
