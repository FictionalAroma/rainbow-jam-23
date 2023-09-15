using DataObjects;
using Management;
using Management.Data;
using NPCS;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCManager : MonoSingleton<NPCManager>
{
    WorldData WorldData;
    List<AdventurerData> theGraveYard = new List<AdventurerData>();
    List<Adventurer> adventurersAlive = new List<Adventurer>();
    NPCGenerator _generator;
    protected override void Awake()
    {
        base.Awake();
        
    }
    private void Start()
    {
        WorldData = WorldDataManager.Instance.TheWorld;
        PopulateNPCs(WorldData.AdventurerList);
        TimeManager.Instance.OnTick += OnNPCTick;

    }

    public void GenerateAdventurer()
    {
        var characterSheet = _generator.GenerateCharacter();
        var newAdventurer = new Adventurer(new AdventurerData() { CharacterStats = characterSheet });
        adventurersAlive.Add(newAdventurer);

    }
   
    public void OnNPCTick()
    {
        foreach (var adventurer in adventurersAlive)
        {
            adventurer.Tick();
        }
    }
    private void PopulateNPCs(List<AdventurerData> adventurers)
    {
        foreach (var adventurer in adventurers)
        {
           
            if (!adventurer.IsAlive) 
            {
                theGraveYard.Add(adventurer);
            }
            else
            {
                var adventurerCreated = new Adventurer(adventurer);
                adventurersAlive.Add(adventurerCreated);
                
            }
        }
    }
}
