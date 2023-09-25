using Assets.Scripts.NPCS.UI;
using UnityEngine;

public class UIManager : MonoSingleton<UIManager>
{
	[SerializeField] private CharacterUI characterUI;
	[SerializeField] private SoundEffectGenerator paperSounds;

	public CharacterUI CharacterUI => characterUI;

	public void Start()
	{
		characterUI.SoundEffectGenerator = paperSounds;
	}
}
