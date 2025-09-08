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

    public class ApartConfig : IEntityTypeConfiguration<Apartment>
    {
        public void Configure(EntityTypeBuilder<Apartment> builder)
        {
            builder.HasKey(d => d.ApartId);
            builder.Property(u => u.ApartId).HasColumnName("UserId");
            builder.HasOne(d => d.ApartType)
                .WithMany(dt => dt.Apartments)
                .HasForeignKey(d => d.ApartTypeId);

            builder.HasOne(d => d.ApartUser)        
                .WithMany(au => au.Apartments)
                .HasForeignKey(d => d.ApartUserId);
        }
    };

};