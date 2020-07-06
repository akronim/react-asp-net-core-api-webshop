using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebShopApiCore.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {
        }

        public DbSet<Item> Items { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<QuantityPromotion> QuantityPromotions { get; set; }
        public DbSet<FinalCostPromotion> FinalCostPromotions { get; set; }
        public DbSet<ItemQuantityPromotion> ItemQuantityPromotions { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderFinalCostPromotion> OrderFinalCostPromotions { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();
        }
    }
}
