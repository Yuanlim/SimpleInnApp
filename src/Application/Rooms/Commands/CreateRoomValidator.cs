using SimpleInnApp.Domain.Enums;
using SimpleInnApp.Domain.Interfaces;

namespace SimpleInnApp.Application.Rooms.Commands;

/// <summary>
/// Validator for creating room
/// </summary>
class CreateRoomValidator : IValidator<CreateRoomCommand, (RoomType?, string?)>
{
    /// <summary>
    /// <para>This validator checks create room JSON to avoid messy EF Core errors.</para>
    /// <para>Rule 1: Name should not be null or whitespace. (weird)</para>
    /// <para>Rule 2: RoomType must be valid.</para>
    /// </summary>
    /// <returns>RoomType if existed, and the reason this json is not valid<returns>
    public (RoomType?, string?) IsValid(CreateRoomCommand command)
    {
        // Check name is null or whitespace
        if (String.IsNullOrWhiteSpace(command.Name))
            return (null, "Name is empty or just whitespace"); // just return because alr invalid

        foreach (var eachType in Enum.GetValues<RoomType>())
        {
            if (command.Type.Equals(eachType.ToString(), StringComparison.InvariantCultureIgnoreCase))
            {
                return (eachType, null);
            }
        }

        return (null, "Not a valid RoomType, RoomType can only be 'Single', 'Double' or 'Suite'");
    }
}