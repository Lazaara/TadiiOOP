using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace Server;

public sealed class JwtOptions {
    public string Issuer { get; set; } = "tadii";
    public string Audience { get; set; } = "tadii.client";
    public string Key { get; set; } = ""; // set via config/Secrets
}

public static class JwtExtensions {
    public static IServiceCollection AddJwtAuth(this IServiceCollection services, IConfiguration config) {
        services.Configure<JwtOptions>(config.GetSection("Jwt"));

        JwtOptions opts = new JwtOptions();
        config.Bind("Jwt", opts);

        if (string.IsNullOrWhiteSpace(opts.Key))
            throw new InvalidOperationException("Jwt:Key is missing.");

        SymmetricSecurityKey signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(opts.Key));

        services
            .AddAuthentication(o => {
                o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(o => {
                o.TokenValidationParameters = new TokenValidationParameters {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    ValidIssuer = opts.Issuer,
                    ValidAudience = opts.Audience,
                    IssuerSigningKey = signingKey,
                    ClockSkew = TimeSpan.FromMinutes(1)
                };
            });

        services.AddAuthorization();

        return services;
    }
}