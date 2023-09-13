using CommonComponents.Interfaces;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NpcCharacterUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI firstName, lastName, level, npcClass, race, strength, dexterity, constitution, intelligence, wisdom, charisma;
    [SerializeField] TextMeshProUGUI healthPoints;
	[SerializeField] TextMeshProUGUI healthPointsMax;
	[SerializeField] TextMeshProUGUI armorClass;
	[SerializeField] TextMeshProUGUI traits, flaws, ideals, skills;
    Canvas _npcharacterSheetCanvas;

	public void PopulateUI(CharacterSheet characterSheet)
	{
        firstName.text = characterSheet.firstName;
		lastName.text = characterSheet.lastName;
		level.text = characterSheet.level.ToString();
		npcClass.text = characterSheet.npcClass;
		race.text = characterSheet.race.ToString();
		strength.text = characterSheet.strength.ToString();
		dexterity.text = characterSheet.dexterity.ToString();
		constitution.text = characterSheet.intelligence.ToString();
		intelligence.text = characterSheet.intelligence.ToString();
		wisdom.text = characterSheet.wisdom.ToString();
		charisma.text = characterSheet.charisma.ToString();
		healthPoints.text = characterSheet.healthPoints.ToString();
		healthPointsMax.text = characterSheet.healthPointsMax.ToString();
		armorClass.text = characterSheet.armorClass.ToString();
		traits.text = characterSheet.neg_traits.ToString()+characterSheet.pos_traits.ToString();
		flaws.text = characterSheet.flaws.ToString();
		ideals.text = characterSheet.ideals.ToString();
		skills.text = characterSheet.skills.ToString();

    }
    public bool Action(InteractableActor actor)
	{
		if (actor != null)
		{
			_npcharacterSheetCanvas.enabled = !_npcharacterSheetCanvas.enabled;
            return true;
        }

		return false;

	}
   
}
