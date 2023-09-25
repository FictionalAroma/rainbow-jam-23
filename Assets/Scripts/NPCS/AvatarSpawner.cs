using System;
using System.Collections.Generic;
using NPCS.Avatars;
using UnityEditor.U2D.Aseprite;
using UnityEngine;
using Random = UnityEngine.Random;

public class AvatarSpawner : MonoBehaviour
{
	[SerializeField] private List<Transform> spawnPositions;
	[SerializeField] private AdventurerAvatar avatarBase;
	[SerializeField] private Transform spawningParent;
	private List<AdventurerAvatarSkin> skinChache;
	private UIManager _uiChache;

	[SerializeField] private AsepriteFile body;

	private void Start()
	{
		NPCManager npcCache = FindObjectOfType<NPCManager>();
		if (npcCache != null)
		{
			skinChache = npcCache.SkinRepoList;
		}
		_uiChache = FindObjectOfType<UIManager>();
	}

	public void CreateAvatar(Adventurer npc)
	{
		var spawnPos = spawnPositions[Random.Range(0, spawnPositions.Count)].position;
		var newAdventurer = Instantiate(avatarBase, spawnPos, Quaternion.identity, spawningParent);
		newAdventurer.Setup(npc, _uiChache);
		AdventurerAvatarSkin foundSkin = null;
		foreach (var skin in skinChache)
		{
			if (string.Compare(npc.CharacterStats.race, skin.skinRace, StringComparison.Ordinal) == 0)
			{
				foundSkin = skin;
				break;
			}
		}

		if (foundSkin == null)
		{
			foundSkin = skinChache[0];
		}

		newAdventurer.SetAnimators(foundSkin.GetBody(npc.CharacterStats.bodyPartNum),
								   foundSkin.GetHead(npc.CharacterStats.headPartNum),
								   foundSkin.GetHair(npc.CharacterStats.hairPartNum));
	}
}
