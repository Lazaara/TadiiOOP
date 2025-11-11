using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using Client.Auth;

namespace Client.Net;

public interface IApiClient
{
    Task<Result<T>> GetAsync<T>(string path, CancellationToken ct = default);
    Task<Result<T>> PostAsync<TReq, T>(string path, TReq body, CancellationToken ct = default);
    void SetBearerToken(string? token);
    string BaseAddress { get; }
}

public sealed class ApiClient : IApiClient, IDisposable {
    private readonly HttpClient _http;

    private readonly JsonSerializerOptions _json = new() {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        PropertyNameCaseInsensitive = true
    };

    public string BaseAddress => _http.BaseAddress?.ToString() ?? "";

    public ApiClient(string baseAddress, HttpMessageHandler? handler = null) {
        _http = handler is null ? new HttpClient() : new HttpClient(handler, disposeHandler: false);
        _http.BaseAddress = new Uri(baseAddress.TrimEnd('/') + "/");
        _http.Timeout = TimeSpan.FromSeconds(15);
        _http.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    }

    public void SetBearerToken(string? token) {
        if (string.IsNullOrWhiteSpace(token))
            _http.DefaultRequestHeaders.Authorization = null;
        else
            _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
    }
    
    public string? GetBearerToken() => _http.DefaultRequestHeaders.Authorization?.Parameter;

    public async Task<Result<T>> GetAsync<T>(string path, CancellationToken ct = default) {
        try {
            using HttpResponseMessage res = await _http.GetAsync(path, ct);
            string content = await res.Content.ReadAsStringAsync(ct);

            if (!res.IsSuccessStatusCode)
                return Result<T>.Fail($"GET {path} failed ({(int)res.StatusCode}): {content}");

            T? value = JsonSerializer.Deserialize<T>(content, _json);
            return value is null ? Result<T>.Fail("Empty response") : Result<T>.Success(value);
        }
        catch (Exception ex) {
            return Result<T>.Fail($"GET {path} error: {ex.Message}");
        }
    }

    public async Task<Result<T>> PostAsync<TReq, T>(string path, TReq body, CancellationToken ct = default) {
        try {
            string json = JsonSerializer.Serialize(body, _json);
            using StringContent req = new StringContent(json, Encoding.UTF8, "application/json");
            using HttpResponseMessage res = await _http.PostAsync(path, req, ct);
            string content = await res.Content.ReadAsStringAsync(ct);

            if (!res.IsSuccessStatusCode)
                return Result<T>.Fail($"POST {path} failed ({(int)res.StatusCode}): {content}");

            T? value = JsonSerializer.Deserialize<T>(content, _json);
            return value is null ? Result<T>.Fail("Empty response") : Result<T>.Success(value);
        }
        catch (Exception ex) {
            return Result<T>.Fail($"POST {path} error: {ex.Message}");
        }
    }

    public void Dispose() => _http.Dispose();
}