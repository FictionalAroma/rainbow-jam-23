using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "NewCharacter", menuName = "Character/New Character")]
public class CharacterSheet : ScriptableObject
{
	[Header("Character Details")]
	[SerializeField] private string firstName;
	[SerializeField] private string lastName;
	[SerializeField] private string race;

	[Header("Character Class")]
	[SerializeField] private int level;
	[SerializeField] private string npcClass;
	[SerializeField] private string[] skills;

	
	[Header("Stats")]
	[SerializeField] private int healthPoints;
	[SerializeField] private int healthPointsMax;
	[SerializeField] private int armorClass;
	[SerializeField] private int strength;
	[SerializeField] private int dexterity;
	[SerializeField] private int constitution;
	[SerializeField] private int intelligence;
	[SerializeField] private int wisdom;
	[SerializeField] private int charisma;

	
	[Header("Personality")]
	[SerializeField] private string[] traits;
	[SerializeField] private string[] flaws;
	[SerializeField] private string[] ideals;

}
