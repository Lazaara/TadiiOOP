using Client.Auth;
using Client.Net;
using Server;
using Server.Xml;

namespace Client.User;

public interface IUserController {
    User? User { get; }

    Task<Result<bool>> UpdateUserInformationAsync(string email, CancellationToken ct = default);
    void UpdateUserInformation(string email); // sync wrapper (blocking)
    void Reset();
}

public sealed class UserController : IUserController {
    public static UserController? Instance { get; private set; }

    private readonly IApiClient _api;

    // Stored state
    public User? User { get; private set; }

    public UserController(ApiClient api) {
        if (Instance != null) return;
        
        Instance = this;
        _api = api;
    }
    
    #region Update Information
    public async Task<Result<UserDto>> GetUserInformationAsync(string email, CancellationToken ct = default) {
        string normalized = (email ?? "").Trim().ToLowerInvariant();
        if (string.IsNullOrWhiteSpace(normalized))
            return Result<UserDto>.Fail("Email is required.");

        string path = $"users/by-email/{Uri.EscapeDataString(normalized)}";
        return await _api.GetAsync<UserDto>(path, ct);
    }
    
    public async Task<Result<bool>> UpdateUserInformationAsync(string email, CancellationToken ct = default) {
        Result<UserDto> res = await GetUserInformationAsync(email, ct);

        if (!res.IsSuccess || res.Value is null)
            return Result<bool>.Fail(res.Error ?? "Failed to fetch user.");

        UserDto? u = res.Value;
        switch (u.UserType) {
            case EUserType.NormalUser: User = new NormalUser(u); break;
            case EUserType.DriverUser: User = new DriverUser(u); break;
            case EUserType.None:
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }

        return Result<bool>.Success(true);
    }
    
    public void UpdateUserInformation(string email) {
        UpdateUserInformationAsync(email).GetAwaiter().GetResult();
    }
    
    public void Reset() {
        User = null;
    }
    #endregion
    
    public async Task<Result<bool>> SetOnlineStatusAsync(bool isOnline, CancellationToken ct = default) {
        if (User == null)
            return Result<bool>.Fail("No user loaded.");

        SetOnlineRequest body = new SetOnlineRequest(User.Email, isOnline);
        Result<object> res = await _api.PostAsync<SetOnlineRequest, object>("users/set-online", body, ct);

        if (!res.IsSuccess)
            return Result<bool>.Fail(res.Error ?? "Failed to update online status.");

        Console.WriteLine($"[UserController] Updated online status: {User.Email} → {(isOnline ? "Online" : "Offline")}");
        User.IsOnline = isOnline;
        
        return Result<bool>.Success(true);
    }
    
    public async Task<Result<bool>> IncreaseTotalTripsAsync(CancellationToken ct = default) {
        if (User == null)
            return Result<bool>.Fail("No user loaded.");
        
        if (User is not DriverUser driverUser)
            return Result<bool>.Fail("Current user is not a Driver user.");

        IncreaseTotalTripsRequest body = new IncreaseTotalTripsRequest(User.Email);
        Result<object> res = await _api.PostAsync<IncreaseTotalTripsRequest, object>("users/increase-total-trips", body, ct);

        if (!res.IsSuccess)
            return Result<bool>.Fail(res.Error ?? "Failed to update online status.");

        Console.WriteLine($"[UserController] Updated total trips: {User.Email} → {driverUser.TotalTrips}");
        
        return Result<bool>.Success(true);
    }
}