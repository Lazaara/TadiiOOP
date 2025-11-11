using Microsoft.AspNetCore.SignalR.Client;

namespace Client.User;

public sealed class DriverRealtime {
	public static Action<DriverAssignedPush>? OnDriverAssigned;
	
	private readonly HubConnection _conn;

	public DriverRealtime(string baseUrl, string driverEmail) {
		_conn = new HubConnectionBuilder()
		        .WithUrl($"{baseUrl.TrimEnd('/')}/hubs/driver?email={Uri.EscapeDataString(driverEmail)}")
		        .WithAutomaticReconnect()
		        .Build();

		_conn.On<DriverAssignedPush>("DriverAssigned", msg => {
			Console.WriteLine($"📢 New booking for {driverEmail}: " +
			                  $"From ({msg.StartLat}, {msg.StartLng}) to ({msg.EndLat}, {msg.EndLng})");
			OnDriverAssigned?.Invoke(msg);
		});

		_ = ConnectAsync();
	}

	private async Task ConnectAsync() {
		await _conn.StartAsync();
		Console.WriteLine("Driver connected to real-time booking updates.");
	}

	public record DriverAssignedPush(
		string RiderEmail,
		double StartLat,
		double StartLng,
		double EndLat,
		double EndLng
	);
}