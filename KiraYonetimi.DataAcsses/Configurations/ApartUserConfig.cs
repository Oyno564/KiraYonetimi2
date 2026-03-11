using KiraYonetimi.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KiraYonetimi.DataAcsses.Configurations
{
    public class ApartUserConfig : IEntityTypeConfiguration<ApartUser>
    {
        public void Configure(EntityTypeBuilder<ApartUser> builder)
        {
            builder.Property(x => x.UserPkId).IsRequired();

            // User ↔ ApartUser : 1-to-1
            builder.HasOne(au => au.User)
                   .WithOne(u => u.ApartUser)
                   .HasForeignKey<ApartUser>(au => au.UserPkId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(au => au.UserPkId).IsUnique();

            // ApartUser → Apartments : 1-to-many (Apartment.ApartUserPkId Guid FK)
            builder.HasMany(au => au.Apartments)
                   .WithOne(a => a.ApartUser)
                   .HasForeignKey(a => a.ApartUserPkId)
                   .OnDelete(DeleteBehavior.SetNull);

            // Invoices ilişkisi InvoiceConfig'de tanımlandı (ApartUserPkId Guid FK ile)
        }
    }
}
