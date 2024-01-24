using Infrastructure.DataAccess.XyzHotel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DataAccess.Model;

public class WalletConfiguration : IEntityTypeConfiguration<Wallet>
{
    public void Configure(EntityTypeBuilder<Wallet> builder)
    {
        builder.ToTable("Wallets", "XyzHotel");

        builder.Property(w => w.ID)
            .UseMySqlIdentityColumn();

        builder.Property(w => w.CLIENT_ID)
            .HasColumnName("CLIENT_ID")
            .HasColumnType("CHAR(36)")
            .IsRequired();

        builder.Property(w => w.AMOUNT)
            .HasColumnName("AMOUNT")
            .HasColumnType("DECIMAL(18,2)")
            .IsRequired();

        builder.Property(w => w.CURRENCY)
            .HasColumnName("CURRENCY")
            .HasMaxLength(10)
            .IsRequired();
    }
}