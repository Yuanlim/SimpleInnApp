using SimpleInnApp.Domain.Interfaces;

namespace SimpleInnApp.Application.Bookings.Commands;

class CreateBookingValidator : IValidator<CreateBookingCommand, string?>
{
    /// <summary>
    /// Check if create booking command was valid.
    /// </summary>
    /// <param name="command"></param>
    /// <returns>A reason string</returns>
    public string? IsValid(CreateBookingCommand command)
    {
        if (String.IsNullOrWhiteSpace(command.GuestName))
        {
            return "Your name is null or whitespace";
        }

        // check in is before today
        if (command.CheckInDate < DateTime.Today)
        {
            return "Check in date must be after today's date.";
        }

        // check out is before check in
        if (command.CheckOutDate < command.CheckInDate)
        {
            return "Check out date must be after check in date.";
        }

        // No problem
        return null;
    }
}