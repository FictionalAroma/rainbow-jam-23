using System;
using System.Collections.Generic;
using UnityEditor.U2D.Aseprite;
using UnityEngine;

namespace NPCS.Generator
{
    public class SkinGenerator: MonoBehaviour
	{
		[SerializeField] private List<AsepriteFile> bodyParts;
		[SerializeField] private List<AsepriteFile> headParts;
		[SerializeField] private List<AsepriteFile> hairParts;

	}
}