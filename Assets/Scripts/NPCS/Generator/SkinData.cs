using System.Collections.Generic;
using System.Linq;
using UnityEditor.U2D.Aseprite;
using UnityEngine;

namespace NPCS.Generator
{
	public class SkinData
	{
		[SerializeField] private List<AsepriteFile> bodyParts;
		[SerializeField] private List<AsepriteFile> headParts;
		[SerializeField] private List<AsepriteFile> hairParts;

		public void Test()
		{
			var file = bodyParts.First();
		}
	}
}