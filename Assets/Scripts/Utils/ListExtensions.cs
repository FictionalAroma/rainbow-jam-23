using System.Collections.Generic;
using UnityEngine;

namespace ExtensionClasses
{
	public static class ListExtensions
	{
		public static T[] RandomFromList<T>(this List<T> array, int sizeOfArrayToReturn)
		{
			var arrayToReturn = new T[sizeOfArrayToReturn];
			for (int i = 0; i< sizeOfArrayToReturn; i++)
			{
				arrayToReturn[i] = array.RandomFromList();
			}

			return arrayToReturn;
		}

		public static T RandomFromList<T>(this List<T> array)
		{
			if (array.Count > 0)
			{
				int randomIndex = Random.Range(0, array.Count);
				return array[randomIndex];
			}

			return array[0];
		}


		public static bool IsNullOrEmpty(this string test) => string.IsNullOrEmpty(test);
	}
}