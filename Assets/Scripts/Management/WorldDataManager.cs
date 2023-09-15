using System;
using System.IO;
using UnityEngine;

namespace Management
{
	public class WorldDataManager : MonoBehaviour
	{
		public static WorldDataManager Instance { get; private set; }

		private void Awake()
		{
			if (Instance != null && Instance != this) 
			{ 
				Destroy(this); 
			} 
			else 
			{ 
				Instance = this; 
				DontDestroyOnLoad(this);
				Setup();
			} 
		}

		private NPCGenerator _generator;


		private void Setup()
		{
			_generator = new NPCGenerator(Path.Join(Application.dataPath, "Data/NPC_Randomizer.json"));

		}



	}
}