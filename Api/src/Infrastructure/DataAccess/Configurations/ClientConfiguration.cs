using Infrastructure.DataAccess.XyzHotel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DataAccess.Model;

public class ClientConfiguration : IEntityTypeConfiguration<Client>
{
    public void Configure(EntityTypeBuilder<Client> entity)
    {
        entity.ToTable("Clients", "XyzHotel");
    
        entity.Property(e => e.ID)
            .UseMySqlIdentityColumn();
        entity.Property(e => e.FULLNAME)
            .HasMaxLength(30)
            .IsRequired();
        entity.Property(e => e.EMAIL)
            .HasMaxLength(255)
            .IsRequired();
        entity.Property(e => e.PHONENUMBER)
            .HasMaxLength(10)
            .IsRequired();
        
        entity.HasIndex(e => e.EMAIL).IsUnique();
    }
}
