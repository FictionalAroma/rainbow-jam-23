using System;
using UnityEngine;

[Serializable]
public class AdventurerAction
{
    [field:SerializeField]public int TicksLeft { get; set; }
	[field:SerializeField]public ActionName Action { get; set; }
}

public enum ActionName
{
	None,
	Hospitalized,
	Training,
	Vacation
}
