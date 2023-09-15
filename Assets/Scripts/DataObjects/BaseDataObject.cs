using System;

namespace DataObjects
{
	[Serializable]
	public class BaseDataObject
	{
		public Guid ID { get; set; } = new Guid();
	}
}