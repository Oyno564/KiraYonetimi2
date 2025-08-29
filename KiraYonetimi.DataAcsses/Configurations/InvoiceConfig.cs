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



    public class InvoiceConfig : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder.HasKey(i => i.InvoiceId);
            builder.HasOne(i => i.Apartment)
                .WithMany(a => a.Invoices)
                .HasForeignKey(i => i.ApartId)
            .OnDelete(DeleteBehavior.Cascade);



            builder.HasMany(i => i.Payments)
                .WithOne(p => p.Invoice)
                .HasForeignKey(i => i.InvoiceId);



        }
    };


}
