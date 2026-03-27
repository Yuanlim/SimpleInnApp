namespace SimpleInnApp.Application.Rooms.Commands;

public record PatchRoomCommand
{
    public int Id { get; init; }
    public string? Name { get; init; }
    public string? Type { get; init; }
    public bool? IsAvailable { get; init; }
}