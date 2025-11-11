using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Server.Xml;

namespace Server;

public static class UserEndpoints {
    public static IEndpointRouteBuilder MapUserEndpoints(this IEndpointRouteBuilder app) {
        RouteGroupBuilder group = app.MapGroup("/users").RequireAuthorization();

        // GET /users  => list all users (no password_hash)
        group.MapGet("/", () => {
            List<User> users = UserXmlStorage.LoadAll();
            List<UserDto> result = users
                                   .OrderBy(u => u.Email)
                                   .Select(u => {
                                       EUserType userType = EUserType.NormalUser;
                                       double rating = 0d;
                                       int totalTrips = 0;

                                       if (u is DriverUser driverUser) {
                                           userType = EUserType.DriverUser;
                                           rating = driverUser.Rating;
                                           totalTrips = driverUser.TotalTrips;
                                       }
                                       
                                       return new UserDto(u.Email, u.IsOnline, userType, rating, totalTrips);
                                   })
                                   .ToList();

            return Results.Ok(result);
        });

        // GET /users/by-email/{email} => single user by email (no password_hash)
        group.MapGet("/by-email/{email}", ([FromRoute] string email) => {
            User? user = UserXmlStorage.GetUserByEmail(email);
            if (user == null)
                return Results.NotFound();

            EUserType userType = EUserType.NormalUser;
            double rating = 0d;
            int totalTrips = 0;

            if (user is DriverUser driverUser) {
                userType = EUserType.DriverUser;
                rating = driverUser.Rating;
                totalTrips = driverUser.TotalTrips;
            }
            
            UserDto dto = new UserDto(user.Email, user.IsOnline, userType, rating, totalTrips);
            return Results.Ok(dto);
        });

        // POST /users/set-online  → updates IsOnline
        group.MapPost("/set-online", ([FromBody] SetOnlineRequest body) => {
            if (string.IsNullOrWhiteSpace(body.Email))
                return Results.BadRequest(new { error = "Email is required." });

            User? user = UserXmlStorage.GetUserByEmail(body.Email);
            if (user == null)
                return Results.NotFound(new { error = "User not found." });

            user.IsOnline = body.IsOnline;
            UserXmlStorage.UpsertUser(user);

            return Results.Ok(new { email = user.Email, isOnline = user.IsOnline });
        });
        
        // POST /users/increase-total-trips  → increase totalTrips by 1
        group.MapPost("/increase-total-trips", ([FromBody] IncreaseTotalTripsRequest body) => {
            if (string.IsNullOrWhiteSpace(body.Email))
                return Results.BadRequest(new { error = "Email is required." });

            User? user = UserXmlStorage.GetUserByEmail(body.Email);
            if (user == null || user is not DriverUser driverUser)
                return Results.NotFound(new { error = "User not found." });

            driverUser.TotalTrips++;
            UserXmlStorage.UpsertUser(user);

            return Results.Ok();
        });

        return app;
    }
}