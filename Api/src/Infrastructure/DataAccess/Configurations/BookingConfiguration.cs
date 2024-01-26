using Infrastructure.DataAccess.XyzHotel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DataAccess.Model;

public class BookingConfiguration : IEntityTypeConfiguration<Booking>
{
    public void Configure(EntityTypeBuilder<Booking> builder)
    {
        builder.ToTable("Bookings", "XyzHotel");

        builder.Property(b => b.ID)
            .UseMySqlIdentityColumn();

        builder.Property(b => b.CLIENT_ID)
            .HasColumnName("CLIENT_ID")
            .HasColumnType("CHAR(36)")
            .IsRequired();

        builder.Property(b => b.CHECK_IN_DATE)
            .HasColumnName("CHECK_IN_DATE")
            .IsRequired();

        builder.Property(b => b.NUMBER_OF_NIGHTS)
            .HasColumnName("NUMBER_OF_NIGHTS")
            .IsRequired();

         builder.HasOne(b => b.ROOM)
            .WithMany()
            .HasForeignKey(b => b.ROOM);

        builder.Property(b => b.TOTAL_AMOUNT)
            .HasColumnName("TOTAL_AMOUNT")
            .IsRequired();

        builder.Property(b => b.INITIAL_PAYMENT)
            .HasColumnName("INITIAL_PAYMENT")
            .IsRequired();

        builder.Property(b => b.IS_CONFIRMED)
            .HasColumnName("IS_CONFIRMED")
            .IsRequired();

        builder.Property(b => b.IS_CANCELLED)
            .HasColumnName("IS_CANCELLED")
            .IsRequired();
    }
}