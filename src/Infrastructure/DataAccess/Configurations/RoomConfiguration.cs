using Infrastructure.DataAccess.XyzHotel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DataAccess.Model;

public class RoomConfiguration : IEntityTypeConfiguration<Room>
{
    public void Configure(EntityTypeBuilder<Room> builder)
    {
        builder.ToTable("Rooms", "XyzHotel");

        builder.Property(r => r.ID)
            .UseMySqlIdentityColumn();

        builder.Property(r => r.NAME)
            .HasColumnName("NAME")
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(r => r.PRICE_PER_NIGHT)
            .HasColumnName("PRICE_PER_NIGHT")
            .HasColumnType("DECIMAL(18,2)")
            .IsRequired();

        builder.Property(r => r.OPTIONS)
            .HasColumnName("OPTIONS")
            .HasColumnType("JSON");
    }
}