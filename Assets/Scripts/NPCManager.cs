using Management;
using Management.Data;
using System.Collections.Generic;
using System.IO;
using NPCS;
using UnityEngine;

public class NPCManager : MonoSingleton<NPCManager>
{
    private WorldData _worldData;
	readonly List<AdventurerData> _graveYard = new List<AdventurerData>();
	readonly List<Adventurer> _adventurersAlive = new List<Adventurer>();

	private void Start()
    {
        _worldData = WorldDataManager.Instance.TheWorld;

		
		PopulateNPCs(_worldData.AdventurerList);
        TimeManager.Instance.OnTick += OnNPCTick;

    }

    public void OnNPCTick()
    {
        foreach (var adventurer in _adventurersAlive)
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
                _graveYard.Add(adventurer);
            }
            else
            {
                var adventurerCreated = new Adventurer(adventurer);
                _adventurersAlive.Add(adventurerCreated);
                
            }
        }
    }
}
