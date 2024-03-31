using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace Application.Interfaces
{
    public interface IApplicationDbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Company>? Companies { get; set; }
        public DbSet<Order>? Orders { get; set; }
        public DbSet<IdentityUser>? Users { get; set; }
        Task<int> SaveChanges();
    }
}
