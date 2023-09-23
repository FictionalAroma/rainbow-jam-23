using System;
using Management;
using Management.Data;
using System.Collections.Generic;
using System.Linq;
using DataObjects;
using NPCS;
using UnityEngine;

public class NPCManager : MonoSingleton<NPCManager>
{
    private WorldData _worldData;
	readonly List<AdventurerData> _graveYard = new List<AdventurerData>();
	[SerializeField] private List<Adventurer> _adventurersAlive = new List<Adventurer>();
	[SerializeField] private AvatarSpawner spawner;
    [SerializeField] List<AdventurerAvatarSkin> skinRepoList;
    private void Start()
    {
        _worldData = WorldDataManager.Instance.TheWorld;

		PopulateNPCs(_worldData.AdventurerList);
        TimeManager.Instance.OnTick += OnNPCTick;

    }

	public void AddNewAdventurer()
	{
		var adventurerCreated = WorldDataManager.Instance.GenerateAdventurer();
        _adventurersAlive.Add(adventurerCreated);
		adventurerCreated.ChangeStateEvent += OnAdventurerStateChange;

	}

    public void OnNPCTick()
    {
        foreach (var adventurer in _adventurersAlive)
        {
            adventurer.Tick();
        }
    }

    private void PopulateNPCs(List<Adventurer> adventurers)
    {
        foreach (var adventurer in adventurers)
        {
           
            if (!adventurer.IsAlive) 
            {
                _graveYard.Add(adventurer);
            }
            else
            {
                _adventurersAlive.Add(adventurer);
				adventurer.ChangeStateEvent += OnAdventurerStateChange;
			}
        }
    }

	public Adventurer GetAdventurerByID(Guid id) =>
		_adventurersAlive.FirstOrDefault(adventurer => adventurer.ID == id);

	public void OnAdventurerStateChange(Adventurer npc, NPCState newState)
	{
		switch (newState)
		{
			case NPCState.Idle:
                spawner.CreateAvatar(npc); 
				break;
		}
	}

}
