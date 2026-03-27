namespace SimpleInnApp.Application.Bookings.Commands;

public record CreateBookingCommand
{
    public required string GuestName { get; init; }
    public required int RoomId { get; init; }
    public required DateTime CheckInDate { get; init; }
    public required DateTime CheckOutDate { get; init; }
}