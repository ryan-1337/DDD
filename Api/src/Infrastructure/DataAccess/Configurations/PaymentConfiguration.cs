using Infrastructure.DataAccess.XyzHotel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DataAccess.Model;

public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
{
    public void Configure(EntityTypeBuilder<Payment> entity)
    {
        entity.ToTable("Payments", "XyzHotel");

        entity.Property(p => p.ID)
            .UseMySqlIdentityColumn();
        entity.Property(p => p.AMOUNT)
            .HasColumnType("decimal(18,2)")
            .IsRequired();
        entity.Property(p => p.TIMESTAMP)
            .IsRequired();
        
        entity.HasOne(p => p.Client)
            .WithMany()
            .HasForeignKey(p => p.Client)
            .OnDelete(DeleteBehavior.Cascade); 
    }
}
