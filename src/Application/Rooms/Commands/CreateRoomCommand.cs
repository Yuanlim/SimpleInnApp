namespace SimpleInnApp.Application.Rooms.Commands;

public record CreateRoomCommand
{
    public required string Name { get; init; }
    public required string Type { get; init; }
    public required bool IsAvailable { get; init; }
}