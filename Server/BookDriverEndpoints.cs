using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Server.Xml;

namespace Server;

public static class BookDriverEndpoints {
    public static IEndpointRouteBuilder MapBookDriverEndpoints(this IEndpointRouteBuilder app) {
        RouteGroupBuilder group = app.MapGroup("/book").RequireAuthorization();

        // POST /book/driver
        group.MapPost("/driver", async (
            [FromBody] BookDriverRequest body,
            IHubContext<DriverHub> hub,
            ClaimsPrincipal user,
            CancellationToken ct) => {
            // 1) Validate
            if (!body.IsValid())
                return Results.BadRequest(new { error = "Invalid coordinates." });

            string? riderEmail = user.FindFirstValue(ClaimTypes.NameIdentifier)
                                 ?? user.FindFirstValue(ClaimTypes.Email)
                                 ?? string.Empty;

            if (string.IsNullOrWhiteSpace(riderEmail))
                return Results.Unauthorized();

            // 2) Poll XML for any available driver (online + DriverUser)
            TimeSpan interval = TimeSpan.FromMilliseconds(900);
            string? claimedDriverEmail = null;

            while (!ct.IsCancellationRequested) {
                List<User> users = UserXmlStorage.LoadAll();

                // Find first online driver (case-insensitive), skip the rider themself
                User? driver = users
                               .Where(u => u is DriverUser)
                               .Where(u => u.IsOnline)
                               .FirstOrDefault(u =>
                                   !string.Equals(u.Email, riderEmail, StringComparison.OrdinalIgnoreCase));

                if (driver != null) {
                    claimedDriverEmail = driver.Email;
                    break;
                }

                await Task.Delay(interval, ct);
            }

            if (ct.IsCancellationRequested)
                return Results.Unauthorized(); // client canceled

            if (claimedDriverEmail is null)
                return Results.StatusCode(503); // no driver found

            // 3) Prepare response + push payload
            BookDriverResponse resp = new BookDriverResponse(
                DriverEmail: claimedDriverEmail,
                BookingToken: Convert.ToHexString(System.Security.Cryptography.RandomNumberGenerator.GetBytes(16))
            );

            DriverAssignedPush push = new DriverAssignedPush(
                RiderEmail: riderEmail,
                StartLat: body.StartLat, StartLng: body.StartLng,
                EndLat: body.EndLat, EndLng: body.EndLng
            );

            // 4) Notify the driver group by email (no JWT flow required)
            await hub.Clients
                     .Group($"driver:{claimedDriverEmail.Trim().ToLowerInvariant()}")
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
        double StartLat,
        double StartLng,
        double EndLat,
        double EndLng
    );
}