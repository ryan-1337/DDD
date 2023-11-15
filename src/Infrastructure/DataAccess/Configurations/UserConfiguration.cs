using Infrastructure.DataAccess.XyzHotel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DataAccess.Model;

public class UserConfiguration : IEntityTypeConfiguration<User>
{

    public void Configure(EntityTypeBuilder<User> entity)
    {
        entity.ToTable("User", "XyzHotel");
    
        entity.Property(e => e.ID)
            .UseMySqlIdentityColumn();
        entity.Property(e => e.USERNAME)
            .HasMaxLength(30)
            .IsRequired();
        entity.Property(e => e.EMAIL)
            .HasMaxLength(255)
            .IsRequired();
        entity.Property(e => e.PHONE)
            .HasMaxLength(10)
            .IsRequired();
    }
}
