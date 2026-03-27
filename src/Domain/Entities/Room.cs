namespace SimpleInnApp.Domain.Entities;

public class Booking
{
    public int Id { get; set; }
    public required string GuestName { get; set; }
    public int RoomId { get; set; }
    public required Room Room { get; set; }
    public DateTime CheckInDate { get; set; }
    public DateTime CheckOutDate { get; set; }
}