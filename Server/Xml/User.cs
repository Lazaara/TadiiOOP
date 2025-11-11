using System.Xml.Serialization;

namespace Server.Xml;

[XmlInclude(typeof(NormalUser))]
[XmlInclude(typeof(DriverUser))]
[Serializable]
public abstract class User {
	public string Email { get; set; } = "";
	public string PasswordHash { get; set; } = "";
	public bool IsOnline { get; set; }

	public abstract string UserType { get; }

	public override string ToString() {
		return $"{UserType}: {Email} (Online={IsOnline})";
	}
}