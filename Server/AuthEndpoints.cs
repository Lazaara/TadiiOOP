using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BCrypt.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Server.Xml;

namespace Server;

public static class AuthEndpoints {
    public static IEndpointRouteBuilder MapAuthEndpoints(this IEndpointRouteBuilder app) {
        RouteGroupBuilder group = app.MapGroup("/auth");

        // POST /auth/register  -> create user in XML
        group.MapPost("/register", ([FromBody] RegisterDto body) => {
            string email = NormalizeEmail(body.Email);
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(body.Password))
                return Results.BadRequest(new { error = "Email and password are required." });

            User? existing = UserXmlStorage.GetUserByEmail(email);
            if (existing != null)
                return Results.Conflict(new { error = "Email already registered." });

            string hash = BCrypt.Net.BCrypt.HashPassword(body.Password);

            User user = new NormalUser() {
                Email = email,
                PasswordHash = hash,
                IsOnline = false
            };

            UserXmlStorage.UpsertUser(user);

            return Results.Created("/auth/register", new { email });
        });

        // POST /auth/login  -> validate against XML, return JWT
        group.MapPost("/login", ([FromBody] LoginDto body, IOptions<JwtOptions> jwtOpts) => {
            string email = NormalizeEmail(body.Email);
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(body.Password))
                return Results.BadRequest(new { error = "Email and password are required." });

            User? user = UserXmlStorage.GetUserByEmail(email);
            bool valid = user != null && !string.IsNullOrEmpty(user.PasswordHash) &&
                         BCrypt.Net.BCrypt.Verify(body.Password, user.PasswordHash);

            if (!valid)
                return Results.Unauthorized();

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

        Claim[] claims = [
            new Claim(ClaimTypes.NameIdentifier, email),
            new Claim(ClaimTypes.Email, email)
        ];

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