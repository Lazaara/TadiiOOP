using System.Text.Json;
using GMap.NET;

// for PointLatLng

namespace Client.Map;

public static class Geocoder {
    static readonly HttpClient http = new HttpClient {
        Timeout = TimeSpan.FromSeconds(8)
    };

    public static void Configure(string appId = "YourAppName/1.0", string contactEmail = "you@example.com") {
        http.DefaultRequestHeaders.UserAgent.ParseAdd(appId);
        http.DefaultRequestHeaders.TryAddWithoutValidation("From", contactEmail);

        // Optional: tell GMap itself to identify
        GMap.NET.MapProviders.GMapProvider.UserAgent = $"{appId} ({contactEmail})";
        System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;
    }

    public static async Task<PointLatLng?> GeocodeAsync(string query, CancellationToken ct) {
        string url =
            $"https://nominatim.openstreetmap.org/search?format=jsonv2&q={Uri.EscapeDataString(query)}&limit=1";
        
        Console.WriteLine($"Request Geocode: {url}");

        using HttpRequestMessage req = new HttpRequestMessage(HttpMethod.Get, url);
        req.Headers.Referrer = new Uri("https://yourapp.example.com/");

        using HttpResponseMessage resp = await http.SendAsync(req, HttpCompletionOption.ResponseHeadersRead, ct);
        
        Console.WriteLine($"check 1");

        string json = await resp.Content.ReadAsStringAsync(ct);
        Console.WriteLine(json);
        JsonDocument doc = JsonDocument.Parse(json);

        if (doc.RootElement.ValueKind != JsonValueKind.Array || doc.RootElement.GetArrayLength() == 0)
            return null;

        JsonElement first = doc.RootElement[0];
        if (first.TryGetProperty("lat", out JsonElement latProp) &&
            first.TryGetProperty("lon", out JsonElement lonProp) &&
            double.TryParse(latProp.GetString(), System.Globalization.CultureInfo.InvariantCulture, out double lat) &&
            double.TryParse(lonProp.GetString(), System.Globalization.CultureInfo.InvariantCulture, out double lon)) {
            return new PointLatLng(lat, lon);
        }

        return null;
    }
}