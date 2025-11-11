using Server;
using Server.Xml;

namespace Client.User;

public abstract class User {
	public string Email { get; private set; }
	public bool IsOnline { get; set; }
	
	public abstract EUserType UserType { get; }

	protected User(UserDto userResponse) {
		Email = userResponse.Email;
		IsOnline = userResponse.IsOnline;
	}
}