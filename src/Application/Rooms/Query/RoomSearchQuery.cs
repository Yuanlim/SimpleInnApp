using Microsoft.EntityFrameworkCore;
using SimpleInnApp.Application.Common.Exception;
using SimpleInnApp.Domain.Entities;
using SimpleInnApp.Infrastructure.Data;

namespace SimpleInnApp.Application.Rooms.Query;

class RoomSearchQuery
{

    public async Task<(Room?, IResult?)> RoomSearchBy(int id, ApplicationDbContext db)
    {
        Room? room = await db.Rooms.Where(r => r.Id == id)
                                    .FirstOrDefaultAsync();

        if (room is not null)
            return (room, null);

        return (null, Results.NotFound<ErrorResponse>(
            new()
            {
                Title = "Room not found.",
                Reason = "Unexpected Room Id."
            }
        ));
    }
}