namespace Client.User;

public class User {
	public bool IsLoaded { get; private set; }
	public int Id { get; private set; }
	public string Email { get; private set; }
	public bool IsOnline { get; set; }
	public EUserType UserType { get; private set; }

	public User(UserResponse userResponse) {
		Id = userResponse.Id;
		Email = userResponse.Email;
		IsOnline = userResponse.IsOnline != 0;
		UserType = (EUserType)userResponse.UserTypeID!;
		IsLoaded = true;
	}
}