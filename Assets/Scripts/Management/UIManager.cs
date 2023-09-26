using Assets.Scripts.NPCS.UI;
using Quests;
using UnityEngine;

public class UIManager : MonoSingleton<UIManager>
{
	[SerializeField] private CharacterUI characterUI;
	[SerializeField] private SoundEffectGenerator paperSounds;
	[SerializeField] private QuestManagementUI questUI;

	public CharacterUI CharacterUI => characterUI;
	public QuestManagementUI QuestUI => questUI;

	public void Start()
	{
		characterUI.SoundEffectGenerator = paperSounds;
		questUI.SoundEffectGenerator = paperSounds;
	}
}
