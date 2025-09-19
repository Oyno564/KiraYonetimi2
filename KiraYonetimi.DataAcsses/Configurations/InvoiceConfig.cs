using KiraYonetimi.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class InvoiceConfig : IEntityTypeConfiguration<Invoice>
{
    public void Configure(EntityTypeBuilder<Invoice> builder)
    {
        // Business sequence (NOT PK)
        builder.Property(i => i.InvoiceId)
               .ValueGeneratedOnAdd();

        // Money precision
        builder.Property(i => i.InvoiceAmount)
               .HasColumnType("decimal(18,2)");

        // Invoice (N) -> Apartment (1)
        builder.HasOne(i => i.Apartment)
               .WithMany(a => a.Invoices)
               .HasForeignKey(i => i.ApartmentPkId)   // <-- was ApartPkId
               .OnDelete(DeleteBehavior.SetNull);

    
  

        // Helpful index for lookups
        builder.HasIndex(i => new { i.ApartmentPkId, i.InvoiceYear, i.InvoiceMonth });
    }
}
