using CommonComponents;
using CommonComponents.Interfaces;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class NpcCharacterUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI firstName, lastName, level, npcClass, race, strength, dexterity, constitution, intelligence, wisdom, charisma;
    [SerializeField] TextMeshProUGUI healthPoints;
	[SerializeField] TextMeshProUGUI healthPointsMax;
	[SerializeField] TextMeshProUGUI armorClass;
	[SerializeField] TextMeshProUGUI traits, flaws, ideals, skills;
    Canvas _npcharacterSheetCanvas;

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
