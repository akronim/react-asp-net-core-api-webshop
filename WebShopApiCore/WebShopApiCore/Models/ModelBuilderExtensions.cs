using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebShopApiCore.Models
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>().HasData(
                new Item
                {
                    ItemID = 1,
                    Name = "Smart Hub",
                    Price = 49.99M
                },
                new Item
                {
                    ItemID = 2,
                    Name = "Motion Sensor",
                    Price = 24.99M
                },
                new Item
                {
                    ItemID = 3,
                    Name = "Wireless Camera",
                    Price = 99.99M
                },
                new Item
                {
                    ItemID = 4,
                    Name = "Smoke Sensor",
                    Price = 19.99M
                },
                new Item
                {
                    ItemID = 5,
                    Name = "Water Leak Sensor",
                    Price = 14.99M
                }
            );

            modelBuilder.Entity<FinalCostPromotion>().HasData(
                new FinalCostPromotion
                {
                    FinalCostPromotionID = 1,
                    PercentageValue = 20,
                    Cumulative = false,
                    Description = "20% OFF"
                },
                new FinalCostPromotion
                {
                    FinalCostPromotionID = 2,
                    PercentageValue = 5,
                    Cumulative = true,
                    Description = "5% OFF"
                },
                new FinalCostPromotion
                {
                    FinalCostPromotionID = 3,
                    AbsoluteValue = 20,
                    Cumulative = true,
                    Description = "20 EURO FF"
                }
            );

            modelBuilder.Entity<QuantityPromotion>().HasData(
                new QuantityPromotion
                {
                    QuantityPromotionID = 1,
                    PromoQuantity = 3,
                    PromoPrice = 65,
                },
                new QuantityPromotion
                {
                    QuantityPromotionID = 2,
                    PromoQuantity = 2,
                    PromoPrice = 35,
                }
            );

            modelBuilder.Entity<ItemQuantityPromotion>().HasData(
                new ItemQuantityPromotion
                {
                    ItemQuantityPromotionID = 1,
                    ItemID = 2,
                    QuantityPromotionID = 1,
                },
                new ItemQuantityPromotion
                {
                    ItemQuantityPromotionID = 2,
                    ItemID = 4,
                    QuantityPromotionID = 2,
                }
            );
        }
    }
}
