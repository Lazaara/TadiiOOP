using Server.Xml;

namespace Server;

// Save fields only
public sealed record UserDto(string Email, bool IsOnline, EUserType UserType, double Rating, int TotalTrips);

// Request DTO
public sealed record SetOnlineRequest(string Email, bool IsOnline);

// Request DTO
public sealed record IncreaseTotalTripsRequest(string Email);