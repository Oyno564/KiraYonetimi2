using KiraYonetimi.DataAcsses.Configurations;
using KiraYonetimi.Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace KiraYonetimi.DataAcsses.Context
{
    public class KiraContext : DbContext
    {
        public KiraContext(DbContextOptions<KiraContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Apartment> Apartments { get; set; }
        public DbSet<ApartType> ApartTypes { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<ApartUser> ApartUsers { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<APIUser> APIUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApartConfig).Assembly);
        }
    }
}
