using KiraYonetimi.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KiraYonetimi.DataAcsses.Configurations
{
    public class InvoiceConfig : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder.Property(i => i.InvoiceId).ValueGeneratedOnAdd();

            // ApartPkId → Apartment.PkId (Guid FK)
            builder.HasOne(i => i.Apartment)
                   .WithMany(a => a.Invoices)
                   .HasForeignKey(i => i.ApartPkId)
                   .OnDelete(DeleteBehavior.Cascade);

            // ApartUserPkId → ApartUser.PkId (Guid FK, nullable)
            builder.HasOne(i => i.ApartUser)
                   .WithMany(au => au.Invoices)
                   .HasForeignKey(i => i.ApartUserPkId)
                   .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
