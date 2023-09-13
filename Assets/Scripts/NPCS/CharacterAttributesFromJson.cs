using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAttributesFromJson
{

        public int charisma, wisdom, strength, dexterity, intelligence, constitution;
        public int level;
        public List<string> first_names { get; set; }
        public List<string> surnames { get; set; }
        public List<string> @class { get; set; }
        public List<string> race { get; set; }
        public List<string> traitsPos { get; set; }
        public List<string> traitsNeg { get; set; }
        public List<string> flaws { get; set; }
        public List<string> skills { get; set; }
        public List<string> ideals { get; set; }
  
}
