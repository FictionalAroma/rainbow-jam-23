using System;
using System.Collections.Generic;
using System.Linq;
using GameMenu;
using UnityEngine;
using UnityEngine.UI;

namespace Quests
{
	public class QuestManagementUI : IngameUIBase<QuestsManager>
	{
		[SerializeField] private LayoutGroup layout;
		[SerializeField] private QuestListPanel panelPrefab;
		[SerializeField] private List<QuestListPanel> panelList;

		public void Start()
		{
			panelList = new List<QuestListPanel>();
			Data.NewQuest += OnNewQuest;
		}

		private void OnNewQuest(Quest obj)
		{
			Populate(Data);
		}


		private void ClearContents()
		{
			foreach (var panel in panelList)
			{
				Destroy(panel.gameObject);
			}
			panelList.Clear();
			layout.transform.DetachChildren();

		}

		protected override void Populate(QuestsManager data)
		{
			ClearContents();
			var tempList = data.ActiveQuests.OrderBy(quest => quest.State).ThenBy(quest => quest.TimeRemaining);
			foreach (var quest in tempList)
			{
				var newPanel = Instantiate(panelPrefab, layout.transform);
				newPanel.Populate(quest);
			}

			var rect = layout.GetComponent<RectTransform>();

		}
	}
}
