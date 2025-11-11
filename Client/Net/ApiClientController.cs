namespace Client.Net;

public class ApiClientController {
	public const string URL = "http://localhost:5000/";
	public static ApiClient Api { get; private set; }

	public static void InitApi() {
		Api = new ApiClient(URL);
	}
}