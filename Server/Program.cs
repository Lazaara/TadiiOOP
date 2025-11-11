using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Server;
using Server.Xml;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Config
string cs = builder.Configuration.GetConnectionString("Default")
         ?? throw new InvalidOperationException("Missing connection string 'Default'.");

// Services
// builder.Services.AddSingleton<IDatabaseController>(_ => new DatabaseController(cs));
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

List<User> users = [
	new NormalUser() { Email = "a", IsOnline = true, PasswordHash = BCrypt.Net.BCrypt.HashPassword("a") },
	new DriverUser() {
		Email = "b", IsOnline = true, PasswordHash = BCrypt.Net.BCrypt.HashPassword("b"), Rating = 4.9, TotalTrips = 0
	}
];

UserXmlStorage.SaveAll(users);

// List<User> users = UserXmlStorage.LoadAll();
// Console.WriteLine(UserXmlStorage.FilePath);
// Console.WriteLine(users.Count);

app.Run();