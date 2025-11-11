using System.Text.Json;
using Client.Auth;
using Client.Booking;
using Client.Map;
using Client.User;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using Server;

namespace Client;

public partial class NormalUserForm : Form {
	private bool findCurrentLocation = true;
	private GMapControl gmap;
	private PointLatLng startLocation;
	private PointLatLng directionLocation;
	private CancellationTokenSource? bookingCancelationTokenSource;
	
	private bool isChoosingLocation = false;

	private bool onGmap;
	private bool onConfirmBooking;
	private bool isFindingDriver;

	private User.User? driverUser;

	public NormalUserForm() {
		InitializeComponent();
		
		mainPanel.Show();
		gmapPanel.Hide();
		chooseLocationPanel.Hide();
		
		if (gmap == null) {
			gmap = new GMapControl {
				Dock = DockStyle.Fill
			};
			this.gmapPanel.Controls.Add(gmap);
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
		
		Geocoder.Configure();
	}

	private void NormalUserForm_Load(object sender, EventArgs e) {
		usernameLabel.Text = $"Xin chào, {UserController.Instance?.User?.Email}!";
	}
	
	private void startGoingButton_Click(object sender, EventArgs e) {
		ToChooseLocation();
	}
	
	#region Choose Location
	private void ToChooseLocation() {
		mainPanel.Hide();
		gmapPanel.Hide();
		chooseLocationPanel.Show();
	}
	
	private void currentLocationTextBox_TextChanged(object sender, EventArgs e) {
		
	}

	private void targetLocationTextBox_TextChanged(object sender, EventArgs e) {
		
	}
	
	private void chooseLocationBackButton_Click(object sender, EventArgs e) {
		mainPanel.Show();
		gmapPanel.Hide();
		chooseLocationPanel.Hide();
    }

    private void chooseLocationButton_Click(object sender, EventArgs e) {
	    RetrieveGeoAndStartGMap();
    }

    private async Task RetrieveGeoAndStartGMap() {
	    if (string.IsNullOrEmpty(targetLocationTextBox.Text)) {
		    return;
	    }
	    
	    if (!string.IsNullOrEmpty(currentLocationTextBox.Text)) {
		    PointLatLng? start = await Geocoder.GeocodeAsync(currentLocationTextBox.Text, new CancellationTokenSource().Token);

		    if (start != null) {
			    startLocation = new PointLatLng(start.Value.Lat, start.Value.Lng);
		    } else {
			    PointLatLng currentLocation = await GetCurrentLocationAsync();
			    startLocation = currentLocation;
		    }
		    
		    findCurrentLocation = false;
	    }
	    else {
		    findCurrentLocation = true;
	    }
	    
	    PointLatLng? direction = await Geocoder.GeocodeAsync(targetLocationTextBox.Text, new CancellationTokenSource().Token);
	    
	    if (direction != null) {
		    directionLocation = new PointLatLng(direction.Value.Lat, direction.Value.Lng);
	    } else {
		    PointLatLng currentLocation = await GetCurrentLocationAsync();
		    directionLocation = currentLocation;
	    }
	    
	    StartGmap();
    }
	#endregion

	#region For gmapPanel
	private void StartGmap() {
		mainPanel.Hide();
		gmapPanel.Show();
		chooseLocationPanel.Hide();
		gmapPanel1st.Show();
		gmapPanel2nd.Hide();
		confirmLocationButton.Show();
		findingPanel.Hide();
		foundDriverPanel.Hide();
		backButton.Show();
		
		isChoosingLocation = true;
		onGmap = true;
		
		InitGMap();
	}
	
	// 🔹 Method 1: Initialize GMap and show user's location
	private async void InitGMap() {
		gmap.MapProvider = GMapProviders.GoogleMap;
		GMaps.Instance.Mode = AccessMode.ServerOnly;
		gmap.MinZoom = 0;
		gmap.MaxZoom = 24;
		gmap.Zoom = 12;
		
		
		if (findCurrentLocation) {
			PointLatLng currentLocation = await GetCurrentLocationAsync();
			startLocation = currentLocation;
		}
		
		gmap.Position = startLocation;

		// Add a marker
		// GMapOverlay markers = new GMapOverlay("start");
		// markers.Markers.Add(new GMarkerGoogle(startLocation, GMarkerGoogleType.blue_dot));
		// gmap.Overlays.Add(markers);

		gmapPanel1st.Hide();
		gmapPanel2nd.Show();
		onConfirmBooking = true;
		isChoosingLocation = false;

		priceLabel.Text = $"{CalculateTripPrice():N0} VND";
		DrawPath();
		
		// Attach click event
		// gmap.MouseClick += Gmap_MouseClick;
	}

	// 🔹 Method 2: When user clicks on map, save that location
	private void Gmap_MouseClick(object sender, MouseEventArgs e) {
		// if (!isChoosingLocation) return;
		//
		// if (e.Button == MouseButtons.Left) {
		// 	gmap.MouseClick -= Gmap_MouseClick;
		// 	PointLatLng point = gmap.FromLocalToLatLng(e.X, e.Y);
		// 	directionLocation = point;
		//
		// 	// Optional: show marker at clicked location
		// 	GMapOverlay clickOverlay = new GMapOverlay("direction");
		// 	clickOverlay.Markers.Add(new GMarkerGoogle(point, GMarkerGoogleType.red_dot));
		// 	gmap.Overlays.Add(clickOverlay);
		//
		// 	MessageBox.Show($"Direction set to: {point.Lat}, {point.Lng}");
		// 	
		// 	gmapPanel1st.Hide();
		// 	gmapPanel2nd.Show();
		// 	onConfirmBooking = true;
		// 	isChoosingLocation = false;
		//
		// 	priceLabel.Text = $"{CalculateTripPrice():N0} VND";
		// 	DrawPath();
		// }
	}

	private void DrawPath() {
		GMapOverlay overlay = gmap.Overlays.FirstOrDefault(o => o.Id == "trip")
		              ?? new GMapOverlay("trip");
		if (!gmap.Overlays.Contains(overlay)) gmap.Overlays.Add(overlay);

		overlay.Routes.Clear();
		overlay.Markers.Clear();

		overlay.Markers.Add(new GMarkerGoogle(startLocation, GMarkerGoogleType.blue_dot));
		overlay.Markers.Add(new GMarkerGoogle(directionLocation, GMarkerGoogleType.red_dot));

		List<PointLatLng> points = new List<PointLatLng> { startLocation, directionLocation };
		GMapRoute route = new GMapRoute(points, "trip-line") {
			Stroke = new Pen(Color.DodgerBlue, 3f) {
				DashStyle = System.Drawing.Drawing2D.DashStyle.Solid
			}
		};
		overlay.Routes.Add(route);

		gmap.ZoomAndCenterMarkers("trip"); // or use SetZoomToFitRect(route.GetRect())
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
	
	private void confirmLocationButton_Click(object sender, EventArgs e) {
		confirmLocationButton.Hide();
		gmapPanel2nd.Hide();
		findingPanel.Show();
		isFindingDriver = true;

		StartBooking();
	}
	
	private void cancelBookingButton_Click(object sender, EventArgs e) {
		StopBooking();
	}

	private async Task StartBooking() {
		bookingCancelationTokenSource = new CancellationTokenSource();
		Result<BookDriverEndpoints.BookDriverResponse> res = await BookDriverController.Instance.BookDriverAsync(startLocation.Lat, startLocation.Lng, directionLocation.Lat, directionLocation.Lng, bookingCancelationTokenSource.Token);

		if (!res.IsSuccess) {
			MessageBox.Show($"Booking failed: {res.Error}", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			confirmLocationButton.Show();
			findingPanel.Hide();
			return;
		}

		Result<UserResponse> driverRes = await UserController.Instance.GetUserInformationAsync(res.Value.DriverEmail);
		if (driverRes.IsSuccess) {
			driverUser = new User.User(driverRes.Value);
		}
		
		ToFoundDriver();
	}

	private void StopBooking() {
		if (bookingCancelationTokenSource != null) {
			bookingCancelationTokenSource.Cancel();
		}
	}
	#endregion
	
	#region Trip Panels
	private async void ToFoundDriver() {
		backButton.Hide();
		findingPanel.Hide();
		foundDriverPanel.Show();
		
		foundDriverTextPanel.Show();
		completeDriveTextPanel.Hide();
		completeDriveButton.Hide();

		driverNameText.Text = driverUser?.Email;

		await Task.Delay(5000);
		
		foundDriverTextPanel.Hide();
		completeDriveTextPanel.Show();
		completeDriveButton.Show();
	}
	
	private void completeDriveButton_Click(object sender, EventArgs e) {
		gmapPanel.Hide();
		mainPanel.Show();
	}
	#endregion

	private void backButton_Click(object sender, EventArgs e) {
		if (onConfirmBooking) {
			StopBooking();
			chooseLocationPanel.Show();
			gmapPanel.Hide();
			// gmapPanel1st.Show();
			// gmapPanel2nd.Hide();

			isChoosingLocation = true;
			gmap.MouseClick += Gmap_MouseClick;

			onConfirmBooking = false;
		} else if (onGmap) {
			chooseLocationPanel.Show();
			gmapPanel.Hide();

			onGmap = false;
		}
	}

	public double CalculateTripPrice() {
		// Haversine formula for distance in km
		double R = 6371; // Earth radius in km
		double lat1 = startLocation.Lat * Math.PI / 180.0;
		double lat2 = directionLocation.Lat * Math.PI / 180.0;
		double dLat = (directionLocation.Lat - startLocation.Lat) * Math.PI / 180.0;
		double dLon = (directionLocation.Lng - startLocation.Lng) * Math.PI / 180.0;

		double a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
		           Math.Cos(lat1) * Math.Cos(lat2) *
		           Math.Sin(dLon / 2) * Math.Sin(dLon / 2);
		double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

		double distanceKm = R * c;

		// Example rate: 12,000 VND/km + 10,000 VND base fare
		double baseFare = 10000;
		double perKmRate = 12000;
		double price = baseFare + distanceKm * perKmRate;

		return Math.Round(price, 0);
	}
}