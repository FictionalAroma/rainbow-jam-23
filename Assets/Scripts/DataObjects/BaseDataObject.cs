using System;

namespace DataObjects
{
	[Serializable]
	public class BaseDataObject
	{
		public Guid ID { get; set; }

		public BaseDataObject()
		{
			ID = Guid.NewGuid();
			
		}
	}
}