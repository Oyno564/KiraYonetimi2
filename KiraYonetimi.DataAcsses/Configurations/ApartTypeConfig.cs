using KiraYonetimi.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KiraYonetimi.DataAcsses.Configurations
{
    public class ApartTypeConfig : IEntityTypeConfiguration<ApartType>
    {
        public void Configure(EntityTypeBuilder<ApartType> builder)
        {
            // PK comes from BaseEntity (PkId)
            builder.HasKey(t => t.PkId);

            // Table name (optional, if you don’t like pluralization)
            builder.ToTable("ApartTypes");

            // TypeName is required (adjust max length as needed)
            builder.Property(t => t.TypeName)
                   .IsRequired()
                   .HasMaxLength(100);

            // No need to configure the Apartments navigation here.
            // It’s already configured in ApartmentConfig via:
            // builder.HasOne(a => a.ApartType)...
        }
    }
}
