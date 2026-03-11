using KiraYonetimi.DataAcsses.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace KiraYonetimi.DataAcsses.Context
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<KiraContext>
    {
        public KiraContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<KiraContext>();
            optionsBuilder.UseNpgsql(
                "Host=localhost;Port=5432;Database=KiraYonetimi;Username=postgres;Password=postgres",
                b => b.MigrationsAssembly("KiraYonetimi.API")
            );
            return new KiraContext(optionsBuilder.Options);
        }
    }
}
