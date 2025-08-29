using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Design;
namespace KiraYonetimi.DataAcsses.Context
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<KiraContext>
    {

        public KiraContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<KiraContext>();

            optionsBuilder.UseNpgsql(
                "Host=localhost;Port=5432;Database=DenemeDB;Username=postgres;Password=postgres123",
                b => b.MigrationsAssembly("KiraYonetimi.API") 
            );

            return new KiraContext(optionsBuilder.Options);
        }
    }
}
