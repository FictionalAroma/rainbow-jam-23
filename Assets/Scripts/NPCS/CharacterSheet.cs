using UnityEngine;

[CreateAssetMenu(fileName = "NewCharacter", menuName = "Character/New Character")]
public class CharacterSheet : ScriptableObject
{
	
	[Header("Character Details")]
	public string firstName;
	public string lastName;
	public string race;

	[Header("Character Class")]
	public int level;
	public string npcClass;
	public string[] skills;

	
	[Header("Stats")]
	public int healthPoints;
	public int healthPointsMax;
	public int armorClass;
	public int strength;
	public int dexterity;
	public int constitution;
	public int intelligence;
	public int wisdom;
	public int charisma;

	
	[Header("Personality")]
	public string[] traits;
	public string[] flaws;
	public string[] ideals;

}
