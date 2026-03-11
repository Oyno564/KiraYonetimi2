using KiraYonetimi.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KiraYonetimi.DataAcsses.Configurations
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(u => u.UserId)
                   .UseIdentityByDefaultColumn()
                   .ValueGeneratedOnAdd();

            builder.HasIndex(u => u.Email).IsUnique();

            builder.HasMany(u => u.Payments)
                   .WithOne(p => p.User)
                   .HasForeignKey(p => p.UserPkId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(u => u.Messages)
                   .WithOne(m => m.User)
                   .HasForeignKey(m => m.UserPkId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
