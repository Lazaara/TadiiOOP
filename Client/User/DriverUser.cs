using Server;
using Server.Xml;

namespace Client.User;

[Serializable]
public sealed class DriverUser : User {
	public override EUserType UserType => EUserType.DriverUser;

	public double Rating { get; set; }
	public int TotalTrips { get; set; }
	
	public DriverUser(UserDto userResponse) : base(userResponse) {
		Rating = userResponse.Rating;
		TotalTrips = userResponse.TotalTrips;
	}
}