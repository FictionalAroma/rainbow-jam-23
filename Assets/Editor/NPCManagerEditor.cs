using UnityEditor;
using UnityEngine;

namespace Editor
{
	[CustomEditor(typeof(NPCManager)), CanEditMultipleObjects]
	public class NPCManagerEditor : UnityEditor.Editor
	{
		public override void OnInspectorGUI()
		{
			DrawDefaultInspector();

			NPCManager myManager = (NPCManager)target;
			if (GUILayout.Button("Generate New Adventurer"))
			{
				myManager.AddNewAdventurer();
			}
		}

	}
}