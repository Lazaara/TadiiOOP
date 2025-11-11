using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace Server;

public static class BookDriverEndpoints {
    public static IEndpointRouteBuilder MapBookDriverEndpoints(this IEndpointRouteBuilder app) {
        RouteGroupBuilder group = app.MapGroup("/book").RequireAuthorization();
        
        // POST /book/driver
        group.MapPost("/driver", async (
            [FromBody] BookDriverRequest body,
            IDatabaseController db,
            IHubContext<DriverHub> hub,
            ClaimsPrincipal user,
            CancellationToken ct) => {
            // Basic validation
            if (!body.IsValid()) return Results.BadRequest(new { error = "Invalid coordinates." });

            string riderEmail = user.FindFirstValue(ClaimTypes.NameIdentifier)
                                ?? user.FindFirstValue(ClaimTypes.Email)
                                ?? "";

            if (string.IsNullOrWhiteSpace(riderEmail))
                return Results.Unauthorized();

            TimeSpan interval = TimeSpan.FromMilliseconds(900);

            // Resolve DriverUser type id once
            int driverTypeId = await db.ScalarAsync<int>(@"
                SELECT UserTypeID FROM UserType WHERE TypeName = 'DriverUser' LIMIT 1;
            ");

            // Poll until we find and claim a driver or timeout
            string? claimedDriverEmail = null;

            while (!ct.IsCancellationRequested) {
                List<Dictionary<string, object>> rows = await db.QueryAsync(@"
                    SELECT 
                        u.email
                    FROM users u
                    WHERE u.UserTypeID = @driverTypeId
                      AND u.IsOnline = 1
                    LIMIT 1;",
                    new() {
                        ["@driverTypeId"] = driverTypeId
                    });

                if (rows.Count == 0) {
                    // none available right now → wait and retry
                    await Task.Delay(interval, ct);
                    continue;
                }

                string driverEmail = Convert.ToString(rows[0]["email"]) ?? "";

                claimedDriverEmail = driverEmail;
                break;
            }

            if (ct.IsCancellationRequested) {
                return Results.Unauthorized();
            }

            if (claimedDriverEmail is null)
                return Results.StatusCode(503); // Service Unavailable (no driver found in time)

            // 4) Return booking info + driver info
            BookDriverResponse resp = new BookDriverResponse(
                DriverEmail: claimedDriverEmail!,
                BookingToken: Convert.ToHexString(System.Security.Cryptography.RandomNumberGenerator.GetBytes(16))
            );
            
            DriverAssignedPush push = new DriverAssignedPush(
                RiderEmail: riderEmail,
                StartLat: body.StartLat, StartLng: body.StartLng,
                EndLat: body.EndLat, EndLng: body.EndLng
            );
            
            await hub.Clients
                     .Group($"driver:{claimedDriverEmail!.Trim().ToLowerInvariant()}")
                     .SendAsync("DriverAssigned", push, ct);

            return Results.Ok(resp);
        });

        return app;
    }

    // Request/Response DTOs
    public sealed record BookDriverRequest(
        double StartLat,
        double StartLng,
        double EndLat,
        double EndLng
    ) {
        public bool IsValid() {
            static bool InRange(double v, double min, double max) => v >= min && v <= max;
            return InRange(StartLat, -90, 90) && InRange(EndLat, -90, 90)
                                              && InRange(StartLng, -180, 180) && InRange(EndLng, -180, 180);
        }
    }

    public sealed record BookDriverResponse(
        string DriverEmail,
        string BookingToken
    );
    
    public sealed record DriverAssignedPush(
        string RiderEmail,
        double StartLat, double StartLng,
        double EndLat, double EndLng
    );
}