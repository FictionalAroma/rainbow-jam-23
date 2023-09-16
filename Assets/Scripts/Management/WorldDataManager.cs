using System.IO;
using ExtensionClasses;
using Management.Data;
using NPCS;
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
			}
		}

		private void Start()
		{
			Setup();
		}

		private NPCGenerator _generator;
		private WorldData _world;
		[SerializeField] private bool simulateLoad;
		public WorldData TheWorld => _world;
		public string WorldName;
		public string GameName;

		private void Setup()
		{
			_generator = new NPCGenerator(Path.Join(Application.dataPath, "Data/NPC_Randomizer.json"));
			if (simulateLoad)
			{
				this.LoadWorldData(WorldName, GameName);
			}
		}

		public AdventurerData GenerateAdventurer()
		{
			var newMeat = _generator.GenerateAdventurer();
			_world.AdventurerList.Add(newMeat);
			return newMeat;
		}


		private string GetWorldFilePath(string username, string gameName) =>
			$"{Application.dataPath}/SaveData/{username}/{gameName}.json";

		public void SaveWorldData(string username, string gameName)
		{
			string filePath = GetWorldFilePath(username, gameName);
			JsonUtils.SaveToFile(_world, filePath);

		}

		public void LoadWorldData(string username, string gameName)
		{
			string filePath = GetWorldFilePath(username, gameName);
			_world = JsonUtils.LoadFromFile<WorldData>(filePath) ?? new WorldData();
		}
	}

}