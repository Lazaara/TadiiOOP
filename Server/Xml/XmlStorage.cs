using System.Xml.Serialization;

namespace Server.Xml;

public static class XmlStorage<T> {
	private static readonly XmlSerializer _serializer = new(typeof(List<T>));

	/// <summary>
	/// Saves the data list to an XML file (creates or overwrites it).
	/// </summary>
	public static void Save(string filePath, List<T> data) {
		Directory.CreateDirectory(Path.GetDirectoryName(filePath)!);
		using var stream = new FileStream(filePath, FileMode.Create);
		_serializer.Serialize(stream, data);
	}

	/// <summary>
	/// Loads data from XML file; returns empty list if file not found or invalid.
	/// </summary>
	public static List<T> Load(string filePath) {
		if (!File.Exists(filePath))
			return new List<T>();

		try {
			using var stream = new FileStream(filePath, FileMode.Open);
			return (List<T>)_serializer.Deserialize(stream)!;
		}
		catch {
			return new List<T>();
		}
	}
}