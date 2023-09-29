using System.IO;
using DataObjects;
using ExtensionClasses;
using Management.Data;
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

		private NPCGenerator _npcGenerator;
		private QuestGenerator _questGenerator;
		private WorldData _world;
		[SerializeField] private bool simulateLoad;
		public WorldData TheWorld => _world;
		public string WorldName;
		public string GameName;

		private void Setup()
		{
			_npcGenerator = new NPCGenerator(Path.Join(Application.dataPath, "Data/NPC_Randomizer.json"));
			_questGenerator = new QuestGenerator(Path.Join(Application.dataPath, "Data/Quest_Randomizer.json"));

			if (simulateLoad)
			{
				this.LoadWorldData(WorldName, GameName);
			}
			else
			{
				_world = new WorldData();
			}
			
		}

		public Adventurer GenerateAdventurer()
		{
			var newMeat = _npcGenerator.GenerateAdventurer();
			_world.AdventurerList.Add(newMeat);
			return newMeat;
		}

		public Quest GenerateQuest()
		{
			var newTask = _questGenerator.GenerateQuest();
			_world.QuestList.Add(newTask);
			return newTask;
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