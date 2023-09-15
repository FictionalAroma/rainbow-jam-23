using System.IO;
using ExtensionClasses;
using Management.Data;
using Newtonsoft.Json;
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
		private WorldData _world;
		public WorldData TheWorld => _world;

		private void Setup()
		{
			_generator = new NPCGenerator(Path.Join(Application.dataPath, "Data/NPC_Randomizer.json"));

		}

		private string GetWorldFilePath(string username, string gameName) =>
			Path.Join(Application.dataPath, $"SaveData/{username}, ${gameName}.json");

		public void SaveWorldData(string username, string gameName)
		{
			string filePath = GetWorldFilePath(username, gameName);
			JsonUtils.SaveToFile(_world, filePath);

		}

		public void LoadWorldData(string username, string gameName)
		{
			string filePath = GetWorldFilePath(username, gameName);
			_world = JsonUtils.LoadFromFile<WorldData>(filePath);

		}
	}
}