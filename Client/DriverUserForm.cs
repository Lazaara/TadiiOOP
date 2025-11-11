using System.Text.Json;
using Client.User;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;

namespace Client;

public partial class DriverUserForm : Form {
	
	private GMapControl gmap;
	
	public DriverUserForm() {
		InitializeComponent();

		onlineCheckBox.Checked = UserController.Instance.User.IsOnline;

		DriverRealtime.OnDriverAssigned += OnDriverAssigned;
		
		if (gmap == null) {
			gmap = new GMapControl {
				Dock = DockStyle.Fill
			};
			this.mainPanel.Controls.Add(gmap);
		}
		
		// 1) Ensure TLS 1.2
		System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;

		// 2) Identify yourself (helps with OSM & some hosts)
		GMap.NET.MapProviders.GMapProvider.UserAgent = "YourAppName/1.0 (contact@example.com)";

		// 3) Prefer ServerAndCache (avoid hammering servers), set cache path
		GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerAndCache;
		gmap.CacheLocation = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "GMapCache");

		// 4) Pick a provider you are allowed to use in production
		gmap.MapProvider = GMap.NET.MapProviders.BingMapProvider.Instance; // requires Bing key
		
		InitGMap();
		ToMainMenu();
	}

	private void ToMainMenu() {
		menuPanel.Show();
		tripPanel.Hide();
	}

	private void onlineCheckBox_CheckedChanged(object sender, EventArgs e) {
		SetOnlineStatusAsync(onlineCheckBox.Checked);
	}

	private async Task SetOnlineStatusAsync(bool isOnline) {
		await UserController.Instance.SetOnlineStatusAsync(isOnline);
	}
	
	private void OnDriverAssigned(DriverRealtime.DriverAssignedPush driverAssignedPush) {
		userNameText.Text = driverAssignedPush.RiderEmail;
		Console.WriteLine("Come to this");
		DriveProcess();
	}

	private async void DriveProcess() {
		// menuPanel.Hide();
		tripPanel.BeginInvoke((Action)(() => tripPanel.Visible = true));
		
		foundUserPanel.BeginInvoke((Action)(() => foundUserPanel.Visible = true));
		completePanel.BeginInvoke((Action)(() => completePanel.Visible = false));
		completeDriveButton.BeginInvoke((Action)(() => completeDriveButton.Visible = false));

		await Task.Delay(5000);
		
		foundUserPanel.BeginInvoke((Action)(() => foundUserPanel.Visible = false));
		completePanel.BeginInvoke((Action)(() => completePanel.Visible = true));
		completeDriveButton.BeginInvoke((Action)(() => completeDriveButton.Visible = true));
	}
	
	private void completeDriveButton_Click(object sender, EventArgs e) {
		ToMainMenu();
	}
	
	#region Init Gmap
	private async void InitGMap() {
		gmap.MapProvider = GMapProviders.GoogleMap;
		GMaps.Instance.Mode = AccessMode.ServerOnly;
		gmap.MinZoom = 0;
		gmap.MaxZoom = 24;
		gmap.Zoom = 12;

		PointLatLng currentLocation = await GetCurrentLocationAsync();
		PointLatLng startLocation = currentLocation;
		gmap.Position = startLocation;

		// Add a marker
		GMapOverlay markers = new GMapOverlay("start");
		markers.Markers.Add(new GMarkerGoogle(startLocation, GMarkerGoogleType.blue_dot));
		gmap.Overlays.Add(markers);
	}
	
	private async Task<PointLatLng> GetCurrentLocationAsync() {
		using HttpClient http = new HttpClient();

		try {
			// "https://ipapi.co/json/" or "https://ipinfo.io/json"
			string json = await http.GetStringAsync("https://ipapi.co/json/");
			GeoResult? data = JsonSerializer.Deserialize<GeoResult>(json);

			if (data != null)
				return new PointLatLng(data.Latitude, data.Longitude);
		}
		catch (Exception e) {
			// ignored
		}

		// fallback to a default location if lookup fails
		return new PointLatLng(10.762622, 106.660172);
	}
	
	private class GeoResult {
		public double Latitude { get; set; }
		public double Longitude { get; set; }
	}
	#endregion
}