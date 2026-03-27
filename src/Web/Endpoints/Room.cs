using Microsoft.EntityFrameworkCore;
using SimpleInnApp.Application.Common.Exception;
using SimpleInnApp.Application.Rooms.Commands;
using SimpleInnApp.Application.Rooms.Query;
using SimpleInnApp.Domain.Entities;
using SimpleInnApp.Domain.Enums;
using SimpleInnApp.Infrastructure.Data;

namespace SimpleInnApp.EndPoints;

public static class Rooms
{
    public static RouteGroupBuilder RoomsEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/api/rooms");

        group.MapPost("/", async (
            CreateRoomCommand command,
            ApplicationDbContext db,
            CreateRoomValidator validator
        ) =>
        {
            (RoomType? requestRoomType, string? reason) = validator.IsValid(command);
            if (reason is not null)
                return Results.BadRequest<ErrorResponse>(
                    new()
                    {
                        Title = "Invalid JSON Body",
                        Reason = reason
                    }
                );

            if (requestRoomType is null)
            {
                return Results.BadRequest<ErrorResponse>(
                    new()
                    {
                        Title = "Invalid JSON Body",
                        Reason = reason! // always has reason if RoomType is invalid
                    }
                );
            }

            db.Rooms.Add(new()
            {
                Name = command.Name,
                Type = requestRoomType.Value,
                IsAvailable = command.IsAvailable
            });

            await db.SaveChangesAsync();

            return Results.Created($"/Room/{command.Name}", command.Name);
        });

        group.MapPatch("/", async (
            PatchRoomCommand command,
            ApplicationDbContext db,
            PatchRoomValidator validator,
            RoomSearchQuery query
        ) =>
        {
            (RoomType? requestRoomType, string? reason) = validator.IsValid(command);
            if (reason is not null)
                return Results.BadRequest<ErrorResponse>(
                    new()
                    {
                        Title = "Invalid JSON Body",
                        Reason = reason
                    }
                );

            // Search for that room
            (Room? target, IResult? result) = await query.RoomSearchBy(command.Id, db);
            if (result is not null || target is null)
                return result;

            // Patch it
            target.Name = command.Name ?? target.Name;
            target.Type = requestRoomType ?? target.Type;
            target.IsAvailable = command.IsAvailable ?? target.IsAvailable;

            // Save
            await db.SaveChangesAsync();

            return Results.Ok(target);
        });

        // Return all available rooms
        group.MapGet("/available", async (ApplicationDbContext db) =>
        {
            List<Room> availableRooms = await db.Rooms.Where(r => r.IsAvailable == true)
                                                        .ToListAsync();

            return Results.Ok(availableRooms);
        });

        // Return all rooms
        group.MapGet("/", async (ApplicationDbContext db) =>
        {
            List<Room> availableRooms = await db.Rooms.ToListAsync();

            return Results.Ok(availableRooms);
        });

        return group;
    }
}