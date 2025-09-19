using KiraYonetimi.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KiraYonetimi.DataAcsses.Configurations
{
    public class ApartmentConfig : IEntityTypeConfiguration<Apartment>
    {
        public void Configure(EntityTypeBuilder<Apartment> builder)
        {
            // Table & key
            builder.ToTable("Apartments");
            builder.HasKey(a => a.PkId);

            // ----------------------------
            // Required: ApartType (Option A)
            // ----------------------------
            builder.Property(a => a.ApartTypePkId)
                   .IsRequired(); // non-nullable FK

            builder.HasOne(a => a.ApartType)
                   .WithMany(t => t.Apartments)
                   .HasForeignKey(a => a.ApartTypePkId)
                   .OnDelete(DeleteBehavior.Restrict); // prevent deleting type if apartments exist

            // ----------------------------
            // Optional: ApartUser (make nullable)
            // ----------------------------
          
            // If ApartUser must be required instead, use:
            // builder.Property(a => a.ApartUserPkId).IsRequired();
            // builder.HasOne(a => a.ApartUser)
            //        .WithMany(u => u.Apartments)
            //        .HasForeignKey(a => a.ApartUserPkId)
            //        .OnDelete(DeleteBehavior.Restrict);

            // ----------------------------
            // Useful indexes (optional)
          
        }
    }
}
