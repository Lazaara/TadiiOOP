using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Server;

public static class AuthEndpoints {
    public static IEndpointRouteBuilder MapAuthEndpoints(this IEndpointRouteBuilder app) {
        RouteGroupBuilder group = app.MapGroup("/auth");

        group.MapPost("/register", async (
            [FromBody] RegisterDto body,
            IDatabaseController db) => {
            string email = NormalizeEmail(body.Email);
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(body.Password))
                return Results.BadRequest(new { error = "Email and password are required." });

            int exists = await db.ScalarAsync<int>(
                "SELECT COUNT(*) FROM USERS WHERE email = @email",
                new() { ["@email"] = email });

            if (exists > 0) return Results.Conflict(new { error = "Email already registered." });

            string? hash = BCrypt.Net.BCrypt.HashPassword(body.Password);

            int inserted = await db.ExecuteAsync(
                "INSERT INTO USERS (email, password_hash) VALUES (@email, @hash)",
                new() { ["@email"] = email, ["@hash"] = hash });

            return inserted > 0
                ? Results.Created($"/auth/register", new { email })
                : Results.Problem("Insert failed.");
        });

        group.MapPost("/login", async (
            [FromBody] LoginDto body,
            IDatabaseController db,
            IOptions<JwtOptions> jwtOpts) => {
            string email = NormalizeEmail(body.Email);
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(body.Password))
                return Results.BadRequest(new { error = "Email and password are required." });

            string? storedHash = await db.ScalarAsync<string?>(
                "SELECT password_hash FROM USERS WHERE email = @email LIMIT 1",
                new() { ["@email"] = email });

            bool valid = storedHash is not null && BCrypt.Net.BCrypt.Verify(body.Password, storedHash);
            if (!valid) return Results.Unauthorized();

            string token = IssueJwt(email, jwtOpts.Value);
            return Results.Ok(new { token });
        });

        // Example protected route
        app.MapGet("/me", [Authorize](ClaimsPrincipal user) => {
            string? email = user.FindFirstValue(ClaimTypes.NameIdentifier) ?? user.Identity?.Name;
            return new { email };
        });

        return app;
    }

    // DTOs
    public record RegisterDto(string Email, string Password);

    public record LoginDto(string Email, string Password);

    // Helpers
    private static string NormalizeEmail(string email) => email?.Trim().ToLowerInvariant() ?? "";

    private static string IssueJwt(string email, JwtOptions opts) {
        SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(opts.Key));
        SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        Claim[] claims = new[] {
            new Claim(ClaimTypes.NameIdentifier, email),
            new Claim(ClaimTypes.Email, email)
        };

        JwtSecurityToken token = new JwtSecurityToken(
            issuer: opts.Issuer,
            audience: opts.Audience,
            claims: claims,
            notBefore: DateTime.UtcNow,
            expires: DateTime.UtcNow.AddHours(8),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}