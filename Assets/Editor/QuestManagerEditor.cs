using UnityEditor;
using UnityEngine;

namespace Editor
{
	[CustomEditor(typeof(QuestsManager)), CanEditMultipleObjects]
	public class QuestManagerEditor : UnityEditor.Editor
	{
		public override void OnInspectorGUI()
		{
			DrawDefaultInspector();

			QuestsManager myManager = (QuestsManager)target;
			if (GUILayout.Button("Generate New Quest"))
			{
				myManager.AddNewQuest();
			}
		}

	}
}