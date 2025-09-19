using KiraYonetimi.Entities.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;


using KiraYonetimi.API.Models.Entity;
namespace KiraYonetimi.DataAcsses.Context
{
    public class KiraContext : DbContext
    {

        public KiraContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Apartment> Apartments { get; set; }
        public DbSet<ApartType> ApartTypes { get; set; }
     
        public DbSet<Invoice> Invoices { get; set; }
   
        public DbSet<Message> Messages { get; set; }

       public DbSet<APIUser> APIUsers { get; set; }
    }
};








