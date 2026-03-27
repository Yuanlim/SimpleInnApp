using SimpleInnApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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
    }
}