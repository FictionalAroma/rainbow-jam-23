using NPCS.Avatars;
using System.Collections;
using System.Collections.Generic;
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

}
