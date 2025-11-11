namespace Server.Xml;

[Serializable]
public sealed class DriverUser : User {
	public override string UserType => "DriverUser";

	public double Rating { get; set; } = 5.0;
	public int TotalTrips { get; set; }
}