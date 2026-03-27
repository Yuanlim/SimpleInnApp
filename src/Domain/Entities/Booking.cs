using SimpleInnApp.Domain.Enums;

namespace SimpleInnApp.Domain.Entities;

public class Room
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required RoomType Type { get; set; }
    public bool IsAvailable { get; set; }
};