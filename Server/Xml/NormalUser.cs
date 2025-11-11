
namespace Server.Xml;

[Serializable]
public sealed class NormalUser : User {
	public override string UserType => "NormalUser";
}