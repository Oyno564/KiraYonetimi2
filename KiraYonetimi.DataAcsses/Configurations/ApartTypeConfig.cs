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

    public class ApartTypeConfig : IEntityTypeConfiguration<ApartType>
    {


        public void Configure(EntityTypeBuilder<ApartType> builder)
        {
            builder.HasKey(dy => dy.ApartTypeId);
        }
    }

};
