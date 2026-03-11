using KiraYonetimi.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KiraYonetimi.DataAcsses.Configurations
{
    public class ApartTypeConfig : IEntityTypeConfiguration<ApartType>
    {
        public void Configure(EntityTypeBuilder<ApartType> builder)
        {
            // PK = BaseEntity.PkId (Guid)
            builder.Property(t => t.ApartTypeId).ValueGeneratedOnAdd();
        }
    }
}
