using Assets.Scripts.NPCS.UI;
using UnityEngine;

public class UIManager : MonoSingleton<UIManager>
{
	[SerializeField] private CharacterUI characterUI;

	public CharacterUI CharacterUI => characterUI;
}
