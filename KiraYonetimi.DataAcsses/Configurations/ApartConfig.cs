using KiraYonetimi.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KiraYonetimi.DataAcsses.Configurations
{
    public class ApartConfig : IEntityTypeConfiguration<Apartment>
    {
        public void Configure(EntityTypeBuilder<Apartment> builder)
        {
            // ApartId is a sequential business number, not the PK
            builder.Property(a => a.ApartId).ValueGeneratedOnAdd();

            // ApartType ilişkisi: Guid FK (ApartTypePkId → ApartType.PkId)
            builder.HasOne(a => a.ApartType)
                   .WithMany(t => t.Apartments)
                   .HasForeignKey(a => a.ApartTypePkId)
                   .OnDelete(DeleteBehavior.Restrict);

            // ApartUser ilişkisi: Guid FK (ApartUserPkId → ApartUser.PkId)
            builder.HasOne(a => a.ApartUser)
                   .WithMany(au => au.Apartments)
                   .HasForeignKey(a => a.ApartUserPkId)
                   .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
