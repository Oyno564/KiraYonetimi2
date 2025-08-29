using KiraYonetimi.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KiraYonetimi.DataAcsses.Configurations
{

    public class UserConfig : IEntityTypeConfiguration<User>
    {

        public void Configure(EntityTypeBuilder<User> builder)
        {

            builder.HasKey(u => u.UserId);

            builder.HasMany(p => p.Payments)
                .WithOne(u => u.User)
                .HasForeignKey(u => u.UserId);

            builder.HasMany(m => m.Messages)
                .WithOne(u => u.User)
        .HasForeignKey(u => u.UserId);

        }

    }
}
