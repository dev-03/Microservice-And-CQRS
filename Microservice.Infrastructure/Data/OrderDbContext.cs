using Microsoft.EntityFrameworkCore;
using Microservice.Infrastructure.Models;

namespace Microservice.Infrastructure.Data
{
    public class OrderDbContext : DbContext
    {
        public DbSet<Order> Order { get; set; }

        public OrderDbContext(DbContextOptions<OrderDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                .Property(b => b.Id)
                .ValueGeneratedOnAdd();
            
            modelBuilder.Entity<Order>()
                .Property(b => b.OrderNumber)
                .ValueGeneratedOnAddOrUpdate();
        }
    }
}