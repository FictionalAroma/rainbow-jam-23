using System.Collections.Generic;
using UnityEngine;

public class CharacterRandomizationDataJsonWrapper
{
	public List<CharacterRandomizationData> NPCList { get; set; }
}

public class CharacterRandomizationData
{
	public StatRandomizationData Charisma  { get; set; }
	public StatRandomizationData Wisdom { get; set; }
	public StatRandomizationData Strength { get; set; }
	public StatRandomizationData Dexterity { get; set; }
	public StatRandomizationData Intelligence { get; set; }
	public StatRandomizationData Constitution { get; set; }
	public StatRandomizationData Level { get; set; }
	public List<string> FirstNames { get; set; }
	public List<string> Surnames { get; set; }
	public List<string> Class { get; set; }
	public List<string> Race { get; set; }
	public List<string> TraitsPos { get; set; }
	public List<string> TraitsNeg { get; set; }
	public List<string> Flaws { get; set; }
	public List<string> Skills { get; set; }
	public List<string> Ideals { get; set; }
}

public class StatRandomizationData
{
	public int Min { get; set; }
	public int Max { get; set; }
	public int GetRandomValue => Random.Range(Min, Max + 1);
}
