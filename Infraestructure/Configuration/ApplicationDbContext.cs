using Entities.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection.Metadata;

namespace Infraestructure.Configuration
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        //private readonly IConfiguration _configuration;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            //_configuration = configuration;
        }

        public DbSet<Product> Product { get; set; }
        public DbSet<ApplicationUser> User { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<Promotion> Promotion { get; set; }
        public DbSet<Address> Address { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(
            //    _configuration.GetValue<string>("ConnectionStrings:ConnectionString"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>().Property<int>("Id").IsRequired();
            modelBuilder.Entity<Address>().HasKey("Id");

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
