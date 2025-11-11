using Client.Net;

namespace Client.Auth;

public interface IAuthController {
    bool IsAuthenticated { get; }
    string? Token { get; }

    Task<Result<bool>> RegisterAsync(string email, string password, CancellationToken ct = default);
    Task<Result<bool>> LoginAsync(string email, string password, CancellationToken ct = default);
    Task<Result<MeResponse>> GetMeAsync(CancellationToken ct = default);
    void Logout();
}

public sealed class AuthController : IAuthController {
    private readonly IApiClient _api;
    private string? _token;

    public bool IsAuthenticated => !string.IsNullOrWhiteSpace(_token);
    public string? Token => _token;

    public AuthController(IApiClient apiClient) {
        _api = apiClient;
    }

    public async Task<Result<bool>> RegisterAsync(string email, string password, CancellationToken ct = default) {
        RegisterRequest req = new RegisterRequest(email.Trim().ToLowerInvariant(), password);
        Result<object> res = await _api.PostAsync<RegisterRequest, object>("auth/register", req, ct);
        return res.IsSuccess ? Result<bool>.Success(true) : Result<bool>.Fail(res.Error!);
    }

    public async Task<Result<bool>> LoginAsync(string email, string password, CancellationToken ct = default) {
        LoginRequest req = new LoginRequest(email.Trim().ToLowerInvariant(), password);
        Result<LoginResponse> res = await _api.PostAsync<LoginRequest, LoginResponse>("auth/login", req, ct);

        if (!res.IsSuccess || res.Value is null)
            return Result<bool>.Fail(res.Error ?? "Login failed.");

        _token = res.Value.Token;
        _api.SetBearerToken(_token);
        return Result<bool>.Success(true);
    }

    public async Task<Result<MeResponse>> GetMeAsync(CancellationToken ct = default) {
        if (!IsAuthenticated)
            return Result<MeResponse>.Fail("Not authenticated.");
        return await _api.GetAsync<MeResponse>("me", ct);
    }

    public void Logout() {
        _token = null;
        _api.SetBearerToken(null);
    }
}