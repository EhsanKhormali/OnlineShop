using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Identity.Client;
using Domain.Entities;
using System.Collections.Generic;
using Application.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Runtime.CompilerServices;

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
            
            optionsBuilder.UseSqlServer(ConfigurationExtensions.GetConnectionString(configuration, "DefaultDatabase"), b => b.MigrationsAssembly("OnlineShop"));

        }

        protected override async void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ApplicationUserEntityConfiguration());
            // any guid
            const string ADMIN_ID = "a18be9c0-aa65-4af8-bd17-00bd9344e575";
            // any guid, but nothing is against to use the same one
             const string ROLE_ID = ADMIN_ID;
            //modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole { Name = "User", NormalizedName = "USER", Id = Guid.NewGuid().ToString(), ConcurrencyStamp = Guid.NewGuid().ToString() });
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole { Name = "Admin", NormalizedName = "ADMIN", Id = ROLE_ID, ConcurrencyStamp = ROLE_ID.ToString() });



            var hasher = new PasswordHasher<OnlineShopUser>();
            OnlineShopUser user = new OnlineShopUser
            {
                Id = ADMIN_ID,
                UserName = "admin",
                NormalizedUserName = "admin".ToUpper(),
                Email = "admin@admin.com",
                NormalizedEmail = "admin@admin.com".ToUpper(),
                EmailConfirmed = true,
                SecurityStamp = String.Empty,
                FirstName = "Ihsan",
                LastName = "Hurmali",
                LockoutEnabled = false,
                ConcurrencyStamp = Guid.NewGuid().ToString()

            };
            string password = hasher.HashPassword(user, "123456");
            user.PasswordHash = password;

            modelBuilder.Entity<IdentityUser>().HasData(user); 

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = ROLE_ID,
                UserId = ADMIN_ID
                
            });

            //modelBuilder.Entity<IdentityUserRole<string>>().HasKey(p => new { p.UserId, p.RoleId });


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
