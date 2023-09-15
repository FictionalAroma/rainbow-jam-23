using System;
using ExtensionClasses;
using UnityEngine;

[Serializable]
//[CreateAssetMenu(fileName = "NewCharacter", menuName = "Character/New Character")]
public class CharacterSheet
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
	public string[] neg_traits;
	public string[] pos_traits;
	public string[] flaws;
	public string[] ideals;

	public CharacterSheet(CharacterRandomizationData characterRandomizationData)
	{
		firstName = characterRandomizationData.FirstNames.RandomFromList();
		lastName = characterRandomizationData.Surnames.RandomFromList();
		level = characterRandomizationData.Level.GetRandomValue;//RandomIntFromArray(intData["level"]);
		npcClass = characterRandomizationData.Class.RandomFromList();
		race = characterRandomizationData.Race.RandomFromList();;
		strength = characterRandomizationData.Strength.GetRandomValue;
		dexterity = characterRandomizationData.Dexterity.GetRandomValue;
		constitution = characterRandomizationData.Constitution.GetRandomValue;
		intelligence = characterRandomizationData.Intelligence.GetRandomValue;
		wisdom = characterRandomizationData.Wisdom.GetRandomValue;
		charisma = characterRandomizationData.Charisma.GetRandomValue;
		pos_traits = characterRandomizationData.TraitsPos.RandomFromList(characterRandomizationData.NumOfPosTraits);
		neg_traits= characterRandomizationData.TraitsNeg.RandomFromList(characterRandomizationData.NumOfNegTraits);
		flaws = characterRandomizationData.Flaws.RandomFromList(characterRandomizationData.NumOfFlaws);
		ideals = characterRandomizationData.Ideals.RandomFromList(characterRandomizationData.NumOfIdeals);
		skills = characterRandomizationData.Skills.RandomFromList(characterRandomizationData.NumOfSkills);

	}
}
