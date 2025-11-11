using Microsoft.AspNetCore.Mvc;

namespace Server;

public static class UserEndpoints {
    public static IEndpointRouteBuilder MapUserEndpoints(this IEndpointRouteBuilder app) {
        RouteGroupBuilder group = app.MapGroup("/users").RequireAuthorization();

        // GET /users  => list all users (no password_hash)
        group.MapGet("/", async (IDatabaseController db) => {
            List<Dictionary<string, object>> rows = await db.QueryAsync(@"
                SELECT
                    u.email,
                    u.IsOnline,
                    u.UserTypeID
                FROM USERS u
                ORDER BY u.email;
            ");

            return Results.Ok(rows);
        });

        // GET /users/by-email/{email} => single user by email (no password_hash)
        group.MapGet("/by-email/{email}", async ([FromRoute] string email, IDatabaseController db) => {
            List<Dictionary<string, object>> rows = await db.QueryAsync(@"
                SELECT
                    u.email,
                    u.IsOnline,
                    u.UserTypeID
                FROM USERS u
                WHERE u.email = @email
                LIMIT 1;",
                new() { ["@email"] = email.Trim().ToLowerInvariant() });

            return rows.Count == 0 ? Results.NotFound() : Results.Ok(rows[0]);
        });
        
        // ✅ POST /users/set-online  →  updates IsOnline = 1 or 0
        group.MapPost("/set-online", async ([FromBody] SetOnlineRequest body, IDatabaseController db) =>
        {
            if (string.IsNullOrWhiteSpace(body.Email))
                return Results.BadRequest(new { error = "Email is required." });

            int isOnlineValue = body.IsOnline ? 1 : 0;

            int updated = await db.ExecuteAsync(@"
                UPDATE USERS
                SET IsOnline = @isOnline
                WHERE email = @email;",
                new()
                {
                    ["@isOnline"] = isOnlineValue,
                    ["@email"] = body.Email.Trim().ToLowerInvariant()
                });

            return updated > 0
                ? Results.Ok(new { email = body.Email, isOnline = body.IsOnline })
                : Results.NotFound(new { error = "User not found." });
        });

        return app;
    }
    
    // DTO for /set-online
    public record SetOnlineRequest(string Email, bool IsOnline);
}