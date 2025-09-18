using KiraYonetimi.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class InvoiceConfig : IEntityTypeConfiguration<Invoice>
{
    public void Configure(EntityTypeBuilder<Invoice> builder)
    {
        // PK zaten BaseEntity.PkId üzerinden geliyor (attribute). İstersen:
        // builder.HasKey(i => i.PkId);

        builder.HasOne(i => i.Apartment)
               .WithMany(a => a.Invoices)
               .HasForeignKey(i => i.ApartPkId)
               .OnDelete(DeleteBehavior.Cascade);

        // InvoiceId bir iş/sıra numarası: otomatik artsın ama PK değil.
        builder.Property(i => i.InvoiceId)
               .ValueGeneratedOnAdd();

        // Payments ilişkisi: FK olarak Invoice'un PK'si (Guid PkId) önerilir.
        builder.HasMany(i => i.Payments)
               .WithOne(p => p.Invoice)
               .HasForeignKey(p => p.InvoicePkId);   // Payment tarafını buna göre düzenle
    }
}
