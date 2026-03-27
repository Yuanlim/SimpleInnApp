using SimpleInnApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleInnApp.Domain.Enums;

namespace SimpleInnApp.Infrastructure.Data.Configurations;

public class RoomConfiguration : IEntityTypeConfiguration<Room>
{
    public void Configure(EntityTypeBuilder<Room> builder)
    {
        // Primary key
        builder.HasKey(r => r.Id);

        // Auto increment
        builder.Property(r => r.Id).ValueGeneratedOnAdd();

        // Room name should be unique
        builder.HasIndex(r => r.Name).IsUnique();

        // Initialize some data
        builder.HasData(
            new
            {
                Id = 1,
                Name = "101",
                Type = RoomType.Single,
                IsAvailable = true
            },
            new
            {
                Id = 2,
                Name = "102",
                Type = RoomType.Double,
                IsAvailable = true
            },
            new
            {
                Id = 3,
                Name = "103",
                Type = RoomType.Suite,
                IsAvailable = true
            },
            new
            {
                Id = 4,
                Name = "201",
                Type = RoomType.Single,
                IsAvailable = true
            },
            new
            {
                Id = 5,
                Name = "202",
                Type = RoomType.Double,
                IsAvailable = true
            }
        );
    }
}