using System;
using CommonComponents.Interfaces;
using Interactions;
using UnityEngine;

public class QuestBoard : CharacterInteraction<QuestsManager>
{
	[field:SerializeField] public QuestsManager Data { get; set; }

	private void Start()
	{
		Data = QuestsManager.Instance;
	}

	public override void LinkUI(UIManager manager)
	{
		this.menuToOpen = manager.QuestUI;
	}

	protected override QuestsManager GetData() => Data;
}
