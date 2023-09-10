using CommonComponents;
using CommonComponents.Interfaces;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NPCCharacterUI : Interactable
{
    [SerializeField] TextMeshProUGUI firstName, lastName, level, npcClass, race, strength, dexterity, constitution, intelligence, wisdom, charisma;
    [SerializeField] TextMeshProUGUI health_points, health_points_max, armor_class;
    [SerializeField] TextMeshProUGUI traits, flaws, ideals, skills;
    Canvas npcharacterSheetCanvas;
    void Start()
    {
        
    }
    
    void Update()
    {
        
    }

    public override bool Action(InteractableActor actor)
    {
        if (actor != null)
        {
            if (npcharacterSheetCanvas.enabled == false)
            {
                npcharacterSheetCanvas.enabled = true;
            }
            else
            {
                npcharacterSheetCanvas.enabled = false;
            }
            return true;
        }
        else
        {
            return false;
        }
        
    }
}
