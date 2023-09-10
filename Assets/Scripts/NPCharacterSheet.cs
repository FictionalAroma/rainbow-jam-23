using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCharacterSheet : ScriptableObject
{
    string first_name;
    string last_name;
    int level;
    string race;
    string npc_class;

    int health_points;
    int health_points_max;
    int armor_class;

    int strength, dexterity, constitution, intelligence, wisdom, charisma;

    string[] traits;
    string[] flaws;
    string[] ideals;
    string[] skills;
}
