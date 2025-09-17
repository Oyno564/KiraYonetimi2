using KiraYonetimi.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KiraYonetimi.DataAcsses.Configurations
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            // PK BaseEntity.PkId ise HasKey yazma

            builder.Property(u => u.UserId)
               .UseIdentityAlwaysColumn()     // or .UseIdentityByDefaultColumn()
               .ValueGeneratedOnAdd();

            builder.HasIndex(u => u.UserId).IsUnique();

            builder.HasMany(p => p.Payments)
                   .WithOne(p => p.User)
                   .HasForeignKey(p => p.UserId);

            builder.HasMany(m => m.Messages)
                   .WithOne(m => m.User)
                   .HasForeignKey(m => m.UserId);
        }
    }
}   // ← burada bitiyor, SONRASINDA ';' YOK
