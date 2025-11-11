namespace Client.User;

// DTO must match your server response shape from /users/by-email/{email}
public sealed class UserResponse {
	public int Id { get; set; }
	public string Email { get; set; } = "";
	public int IsOnline { get; set; } = 0; // 0 is offline, 1 is online
	public int? UserTypeID { get; set; }
	public string? UserType { get; set; }
}