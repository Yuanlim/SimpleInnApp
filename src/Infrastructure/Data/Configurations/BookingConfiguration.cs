using SimpleInnApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SimpleInnApp.Infrastructure.Data.Configurations;

public class BookingConfiguration : IEntityTypeConfiguration<Booking>
{
    public void Configure(EntityTypeBuilder<Booking> builder)
    {
        // Primary key
        builder.HasKey(b => b.Id);

        // Auto increment
        builder.Property(b => b.Id).ValueGeneratedOnAdd();

        // Each Booking has one Room, Room can have multiple Bookings
        builder.HasOne(b => b.Room)
                .WithMany()
                .HasForeignKey(b => b.RoomId);
    }
}