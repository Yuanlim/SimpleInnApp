using Microsoft.EntityFrameworkCore;
using SimpleInnApp.Application.Bookings.Commands;
using SimpleInnApp.Application.Common.Exception;
using SimpleInnApp.Application.Rooms.Query;
using SimpleInnApp.Domain.Entities;
using SimpleInnApp.Infrastructure.Data;

public static class Bookings
{
    public static RouteGroupBuilder BookingEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("api/bookings");

        group.MapPost("/", async (
            CreateBookingCommand command,
            ApplicationDbContext db,
            CreateBookingValidator validator,
            RoomSearchQuery query
        ) =>
        {
            string? reason = validator.IsValid(command);

            if (reason is not null)
                return Results.BadRequest<ErrorResponse>(
                    new()
                    {
                        Title = "Invalid JSON Body",
                        Reason = reason
                    }
                );

            // Search for that room
            (Room? target, IResult? result) = await query.RoomSearchBy(command.RoomId, db);
            if (result is not null || target is null)
                return result;

            // Must be available
            if (!target.IsAvailable)
                return Results.Conflict<ErrorResponse>(new()
                {
                    Title = "Room unavailable",
                    Reason = "The room has been booked"
                });

            // Change room status
            target.IsAvailable = false;

            // Create booking
            Booking booking = new()
            {
                GuestName = command.GuestName,
                RoomId = target.Id,
                Room = target,
                CheckInDate = command.CheckInDate,
                CheckOutDate = command.CheckOutDate,
            };

            await db.Bookings.AddAsync(booking);
            await db.SaveChangesAsync();

            return Results.Created($"bookings/{booking}", booking);
        });

        group.MapGet("/", async (ApplicationDbContext db)
        => Results.Ok(await db.Bookings.Include(r => r.Room).ToListAsync()));

        return group;
    }
}