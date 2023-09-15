using System.IO;
using Newtonsoft.Json;

namespace ExtensionClasses
{
	public class JsonUtils
	{
		public static void SaveToFile(object value, string filepath)
		{
			if (!File.Exists(filepath))
			{
				Directory.CreateDirectory(Path.GetDirectoryName(filepath) ?? string.Empty);
				File.Create(filepath);
			}
			using var fileHandle = File.OpenWrite(filepath);
			Serialize(value, fileHandle);
		}

		public static void Serialize(object value, Stream s)
		{
			using StreamWriter writer = new StreamWriter(s);
			using JsonTextWriter jsonWriter = new JsonTextWriter(writer);
			JsonSerializer ser = new JsonSerializer();
			ser.Serialize(jsonWriter, value);
			jsonWriter.Flush();
		}


		public static T LoadFromFile<T>(string filepath)
		{
			using var fileHandle = File.OpenRead(filepath);
			
			return Deserialize<T>(fileHandle);
		}

		public static T Deserialize<T>(Stream s)
		{
			using StreamReader reader = new StreamReader(s);
			using JsonTextReader jsonReader = new JsonTextReader(reader);
			JsonSerializer ser = new JsonSerializer()
								 {MissingMemberHandling = MissingMemberHandling.Ignore, ReferenceLoopHandling = ReferenceLoopHandling.Ignore};
			return ser.Deserialize<T>(jsonReader);
		}


	}
}