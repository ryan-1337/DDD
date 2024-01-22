using Infrastructure.DataAccess.XyzHotel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DataAccess.Model;

public class CurrencyConfiguration : IEntityTypeConfiguration<Currency>
{
    public void Configure(EntityTypeBuilder<Currency> builder)
    {
        builder.ToTable("Currencies", "XyzHotel");

        builder.Property(c => c.ID)
            .UseMySqlIdentityColumn();

        builder.Property(c => c.CODE)
            .HasColumnName("CODE")
            .HasMaxLength(3)
            .IsRequired();

        builder.Property(c => c.NAME)
            .HasColumnName("NAME")
            .HasMaxLength(50)
            .IsRequired();
    }
}