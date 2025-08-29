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
    public class ApartUserConfig : IEntityTypeConfiguration<ApartUser>
    {
        public void Configure(EntityTypeBuilder<ApartUser> builder)
        {
            builder.HasKey(du => du.ApartUserId);

            builder.HasMany(au => au.Apartments)
                .WithOne(a => a.ApartUser)
                .HasForeignKey(a => a.ApartUserId);

            builder.HasOne<User>(au => au.User)   // ApartUser → User
     .WithOne(u => u.ApartUser)        // User → ApartUser
     .HasForeignKey<ApartUser>(au => au.UserId);


            builder.HasMany(i => i.Invoices)
                .WithOne(au => au.ApartUser);
        }
    }

};
