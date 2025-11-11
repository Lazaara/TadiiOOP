using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Server;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Config
string cs = builder.Configuration.GetConnectionString("Default")
         ?? throw new InvalidOperationException("Missing connection string 'Default'.");

// Services
builder.Services.AddSingleton<IDatabaseController>(_ => new DatabaseController(cs));
builder.Services.AddJwtAuth(builder.Configuration);
builder.Services.AddSignalR();

WebApplication app = builder.Build();

// Middleware
app.UseAuthentication();
app.UseAuthorization();

// Endpoints
app.MapGet("/", () => "Tadii Application Online!");
app.MapAuthEndpoints();
app.MapUserEndpoints();
app.MapBookDriverEndpoints();

app.MapHub<DriverHub>("/hubs/driver");

app.Run();