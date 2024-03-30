using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Identity.Client;
using OnlineShop.Models;
using System.Collections.Generic;

namespace OnlineShop.Data
{
    public class OnlineShopContext() : IdentityDbContext<IdentityUser>()
    {
        

        public DbSet<Product>? Products { get; set; }
        public DbSet<Company>? Companies { get; set; }
        public DbSet<Order>? Orders { get; set; }
        public DbSet<IdentityUser>? Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();
            
            optionsBuilder.UseSqlServer(ConfigurationExtensions.GetConnectionString(configuration, "DefaultDatabase"));

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ApplicationUserEntityConfiguration());
        }

    }

    public class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<OnlineShopUser>
    {
        public void Configure(EntityTypeBuilder<OnlineShopUser> builder)
        {
            builder.Property(x => x.FirstName).HasMaxLength(100);
        }
    }
}
