using System;
using System.Threading;
using System.Threading.Tasks;
using Client.Auth;
using Client.Net;
using Server;

namespace Client.Booking;

// DTOs must match server-side BookDriverEndpoints
// public sealed record BookDriverRequest(double StartLat, double StartLng, double EndLat, double EndLng);

public sealed class BookDriverController {
    public static BookDriverController? Instance { get; private set; }
    private readonly IApiClient _api;

    public BookDriverController(IApiClient apiClient) {
        if (Instance != null) return;

        Instance = this;
        _api = apiClient ?? throw new ArgumentNullException(nameof(apiClient));
    }

    public async Task<Result<BookDriverEndpoints.BookDriverResponse>> BookDriverAsync(
        double startLat, double startLng,
        double endLat, double endLng,
        CancellationToken ct = default) {
        
        BookDriverEndpoints.BookDriverRequest req = new BookDriverEndpoints.BookDriverRequest(startLat, startLng, endLat, endLng);

        Console.WriteLine("[BookDriverController] Sending booking request...");

        Result<BookDriverEndpoints.BookDriverResponse> res =
            await _api.PostAsync<BookDriverEndpoints.BookDriverRequest, BookDriverEndpoints.BookDriverResponse>(
                "book/driver", req, ct);

        if (!res.IsSuccess) {
            Console.WriteLine($"[BookDriverController] Booking failed: {res.Error}");
            return Result<BookDriverEndpoints.BookDriverResponse>.Fail(res.Error ?? "Booking failed.");
        }

        Console.WriteLine($"[BookDriverController] Booking success! Driver: {res.Value!.DriverEmail}");
        return Result<BookDriverEndpoints.BookDriverResponse>.Success(res.Value);
    }
}