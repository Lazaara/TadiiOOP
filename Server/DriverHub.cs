using Microsoft.AspNetCore.SignalR;

namespace Server;

public sealed class DriverHub : Hub {
	public override async Task OnConnectedAsync() {
		string? driverEmail = Context.GetHttpContext()?.Request.Query["email"].ToString()?.Trim().ToLowerInvariant();
		if (!string.IsNullOrEmpty(driverEmail)) {
			await Groups.AddToGroupAsync(Context.ConnectionId, $"driver:{driverEmail}");
			Console.WriteLine($"✅ Driver connected: {driverEmail}");
		}
		else {
			Console.WriteLine("⚠️ Missing driver email in connection.");
		}

		await base.OnConnectedAsync();
	}

	public override async Task OnDisconnectedAsync(Exception? exception) {
		string? driverEmail = Context.GetHttpContext()?.Request.Query["email"].ToString()?.Trim().ToLowerInvariant();
		if (!string.IsNullOrEmpty(driverEmail))
			Console.WriteLine($"❌ Driver disconnected: {driverEmail}");

		await base.OnDisconnectedAsync(exception);
	}
}