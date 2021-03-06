using MenuApp.OrderService.Logic.Entities;
using Microsoft.EntityFrameworkCore;

namespace MenuApp.OrderService.EntityFramework.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Session> Sessions { get; set; }
    }
}