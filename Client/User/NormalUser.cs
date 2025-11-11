
using Server;
using Server.Xml;

namespace Client.User;

[Serializable]
public sealed class NormalUser : User {
	public override EUserType UserType => EUserType.NormalUser;
	
	public NormalUser(UserDto userResponse) : base(userResponse) { }
}