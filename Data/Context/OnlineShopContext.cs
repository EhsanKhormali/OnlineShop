using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Identity.Client;
using Domain.Entities;
using System.Collections.Generic;
using Application.Interfaces;
using Microsoft.Extensions.Configuration;

namespace Data.Context
{
    public class OnlineShopContext() : IdentityDbContext<IdentityUser>(),IApplicationDbContext
    {
        

        public DbSet<Product>? Products { get; set; }
        public DbSet<Company>? Companies { get; set; }
        public DbSet<Order>? Orders { get; set; }
        public DbSet<IdentityUser>? Users { get; set; }

        public async Task<int> SaveChanges()
        {
            int n =  base.SaveChanges();
            return n;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();
            
            optionsBuilder.UseSqlServer(ConfigurationExtensions.GetConnectionString(configuration, "DefaultDatabase"));

        }

        protected override async void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ApplicationUserEntityConfiguration());
            // any guid
            const string ADMIN_ID = "a18be9c0-aa65-4af8-bd17-00bd9344e575";
            // any guid, but nothing is against to use the same one
            const string ROLE_ID = ADMIN_ID;
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = ROLE_ID,
                Name = "admin",
                NormalizedName = "admin"
            });

            var hasher = new PasswordHasher<OnlineShopUser>();
            modelBuilder.Entity<OnlineShopUser>().HasData(new OnlineShopUser
            {
                Id = ADMIN_ID,
                UserName = "admin",
                NormalizedUserName = "admin",
                Email = "admin@admin.com",
                NormalizedEmail = "admin@admin.com",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "password"),
                SecurityStamp = "random",
                FirstName = "Ihsan",
                LastName = "Hurmali",
                LockoutEnabled = false,
                

            }); 

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = ROLE_ID,
                UserId = ADMIN_ID,
                
            });


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
