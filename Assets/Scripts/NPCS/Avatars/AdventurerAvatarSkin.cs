using UnityEngine;

[CreateAssetMenu(fileName = "AvatarSkins", menuName = "Character/New Avatar Skin Repo")]
public class AdventurerAvatarSkin: ScriptableObject 
{
    public string skinRace;
    [SerializeField]
    AnimatorOverrideController[] headOverrideControllers;
    [SerializeField]
    AnimatorOverrideController[] hairOverrideControllers;
    [SerializeField]
    AnimatorOverrideController[] bodyOverrideControllers;

	public AnimatorOverrideController GetHead(int index) => headOverrideControllers.Length < index ? headOverrideControllers[index] : headOverrideControllers[0];
	public AnimatorOverrideController GetHair(int index) => hairOverrideControllers.Length < index ? hairOverrideControllers[index] : hairOverrideControllers[0];
	public AnimatorOverrideController GetBody(int index) => bodyOverrideControllers.Length < index ? bodyOverrideControllers[index] : bodyOverrideControllers[0];

}
