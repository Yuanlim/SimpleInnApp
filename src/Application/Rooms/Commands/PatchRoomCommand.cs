using SimpleInnApp.Application.Rooms.Commands;
using SimpleInnApp.Domain.Enums;
using SimpleInnApp.Domain.Interfaces;

namespace SimpleInnApp.Application.Rooms.Commands;
/// <summary>
/// Validator for patching room
/// </summary>
class PatchRoomValidator : IValidator<PatchRoomCommand, (RoomType?, string?)>
{
    /// <summary>
    /// <para>This validator checks patch room JSON to avoid messy EF Core errors.</para>
    /// <para>Rule 1: Name should not be null or whitespace. (if provided)</para>
    /// <para>Rule 2: RoomType must be valid. (if provided)</para>
    /// <para>Rule 3: You can have null field but not all.</para>
    /// </summary>
    /// <returns>RoomType if existed, and the reason this json is not valid<returns>
    public (RoomType?, string?) IsValid(PatchRoomCommand command)
    {
        // Check name is null
        if (command.Name is not null)
        {
            // Not null intent to patch name
            if (String.IsNullOrWhiteSpace(command.Name))
            {
                return (null, "Name is empty or just whitespace");
            }
            return (null, null);
        }

        if (command.Type is not null)
        {
            // Check valid room type
            foreach (var eachType in Enum.GetValues<RoomType>())
            {
                if (command.Type.Equals(eachType.ToString(), StringComparison.InvariantCultureIgnoreCase))
                {
                    return (eachType, null);
                }
            }
            return (null, "Not a valid RoomType, RoomType can only be 'Single', 'Double' or 'Suite'");
        }

        if (command.IsAvailable is not null)
            return (null, null);

        // Everything is null invalid
        return (null, "Must provide at least one field to patch.");
    }
}