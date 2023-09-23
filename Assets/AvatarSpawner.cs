using System.Collections.Generic;
using NPCS.Avatars;
using UnityEngine;

public class AvatarSpawner : MonoBehaviour
{
	[SerializeField] private List<Transform> spawnPositions;
	[SerializeField] private AdventurerAvatar avatarBase;
	[SerializeField] private Transform spawningParent;
	private UIManager _uiChache;

	private void Start()
	{
		_uiChache = FindObjectOfType<UIManager>();
	}

	public void CreateAvatar(Adventurer npc)
	{
		var spawnPos = spawnPositions[Random.Range(0, spawnPositions.Count)].position;
		var newAdventurer = Instantiate(avatarBase, spawnPos, Quaternion.identity, spawningParent);
		newAdventurer.Setup(npc, _uiChache);
	}
}
