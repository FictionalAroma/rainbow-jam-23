using System;
using UnityEngine;

namespace NPCS.Avatars
{
	[RequireComponent(typeof(SpriteRenderer))]
	public class AdventurerAvatar : MonoBehaviour
	{
		[SerializeField] private Adventurer data;

		public Adventurer Data => data;

		public void Awake()
		{

		}
	}
}