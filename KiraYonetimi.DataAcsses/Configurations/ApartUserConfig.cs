/* using KiraYonetimi.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KiraYonetimi.DataAcsses.Configurations
{
    public class ApartUserConfig : IEntityTypeConfiguration<ApartUser>
    {
        public void Configure(EntityTypeBuilder<ApartUser> builder)
        {
            // PK is BaseEntity.PkId (Guid)
            builder.Property(x => x.UserPkId).IsRequired();

            // 1–1 ApartUser <-> User by UserPkId
            builder.HasOne(au => au.User)
                   .WithOne(u => u.ApartUser)
                   .HasForeignKey<ApartUser>(au => au.UserPkId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(au => au.UserPkId).IsUnique();

            // 1–N ApartUser -> Apartments (FK on Apartment: ApartUserPkId)
            builder.HasMany(au => au.Apartments)
                   .WithOne(a => a.ApartUser)
                   .HasForeignKey(a => a.ApartUserPkId)
                   .OnDelete(DeleteBehavior.SetNull);

            // 1–N ApartUser -> Invoices (FK on Invoice: ApartUserPkId)
            builder.HasMany(au => au.Invoices)
                   .WithOne(i => i.ApartUser)
                   .HasForeignKey(i => i.ApartUserPkId)
                   .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
 */