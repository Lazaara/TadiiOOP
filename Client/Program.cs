using Client.Net;
using Client.Auth;
using Client.Booking;
using Client.User;

namespace Client;

static class Program {
	/// <summary>
	///  The main entry point for the application.
	/// </summary>
	[STAThread]
	static async Task Main() {
		ApiClientController.InitApi();
		
		ApplicationConfiguration.Initialize();
		Application.Run(new LoginForm());
	}

	public static void InstantiateSingletonForNormalUser() {
		new BookDriverController(ApiClientController.Api);
	}

	public static void InstantiateSingletonForDriverUser() {
		new DriverRealtime(
			ApiClientController.URL,
			UserController.Instance.User.Email);
	}
}