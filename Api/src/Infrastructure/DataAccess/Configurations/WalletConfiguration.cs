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
        
        builder.HasOne(w => w.CLIENT_ID)
            .WithMany()
            .HasForeignKey(w => w.CLIENT_ID)
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