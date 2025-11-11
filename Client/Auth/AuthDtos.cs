namespace Client.Auth;

public sealed record RegisterRequest(string Email, string Password);
public sealed record LoginRequest(string Email, string Password);

public sealed record LoginResponse(string Token);
public sealed record MeResponse(string Email);

public class Result<T> {
	public bool IsSuccess { get; init; }
	public T? Value { get; init; }
	public string? Error { get; init; }

	public static Result<T> Success(T value) => new() { IsSuccess = true, Value = value };
	public static Result<T> Fail(string error) => new() { IsSuccess = false, Error = error };
}