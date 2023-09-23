using System.Collections;
using System.Collections.Generic;
using CommonComponents.Interfaces;
using Interactions;
using UnityEngine;

public class QuestBoard : CharacterInteraction
{

	public override bool Action(InteractableActor interactableActor)
	{
		return true;
	}

	public override void LinkUI(UIManager manager)
	{

	}
}
