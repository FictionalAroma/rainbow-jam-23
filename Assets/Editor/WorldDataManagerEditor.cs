using Management;
using UnityEditor;
using UnityEngine;

	[CustomEditor(typeof(WorldDataManager)), CanEditMultipleObjects]
	public class WorldDataManagerEditor : UnityEditor.Editor
	{
		public override void OnInspectorGUI()
		{
			DrawDefaultInspector();

			WorldDataManager myManager = (WorldDataManager)target;
			if (GUILayout.Button("Write Current Data"))
			{
				myManager.SaveWorldData(myManager.WorldName, myManager.GameName);
			}

			if (GUILayout.Button("Load World Data"))
			{
				myManager.LoadWorldData(myManager.WorldName, myManager.GameName);
			}

		}

	}
