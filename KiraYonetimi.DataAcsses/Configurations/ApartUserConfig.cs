using KiraYonetimi.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KiraYonetimi.DataAcsses.Configurations
{
    public class ApartUserConfig : IEntityTypeConfiguration<ApartUser>
    {
        public void Configure(EntityTypeBuilder<ApartUser> builder)
        {
            // PK BaseEntity.PkId ise HasKey yazma

            builder.Property(x => x.UserPkId).IsRequired();

            builder.HasOne(au => au.User)
        .WithOne(u => u.ApartUser)
        .HasForeignKey<ApartUser>(au => au.UserPkId)     // 1–1 by PK Guid
        .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(au => au.UserPkId).IsUnique();

            builder.HasMany(au => au.Apartments)
                   .WithOne(a => a.ApartUser)
                   .HasForeignKey(a => a.ApartUserId);

            builder.HasOne(au => au.Apartments)
       .WithMany(a => a.ApartUser)                     // if you allow many
       .HasForeignKey(au => au.ApartmentPkId)           // GUID FK
       .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(au => au.Invoices)
                   .WithOne(i => i.ApartUser);
        }
    }
}   // ← burada bitiyor, SONRASINDA ';' YOK
