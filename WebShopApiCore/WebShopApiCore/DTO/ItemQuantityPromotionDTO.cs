using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShopApiCore.Models;

namespace WebShopApiCore.DTO
{
    public class ItemQuantityPromotionDTO
    {
        public Int32 ItemQuantityPromotionID { get; set; }

        public Int32 ItemID { get; set; }

        public String Name { get; set; }

        public Decimal Price { get; set; }

        public Int32 QuantityPromotionID { get; set; }

        public Int32 PromoQuantity { get; set; }

        public Decimal PromoPrice { get; set; }

        public String Description { get; set; }

        public static ItemQuantityPromotionDTO FromEntity(ItemQuantityPromotion entity)
        {
            return new ItemQuantityPromotionDTO
            {
                ItemQuantityPromotionID = entity.ItemQuantityPromotionID,
                ItemID = entity.ItemID,
                Name = entity.Item.Name,
                Price = entity.Item.Price,
                QuantityPromotionID = entity.QuantityPromotionID,
                PromoQuantity = entity.QuantityPromotion.PromoQuantity,
                PromoPrice = entity.QuantityPromotion.PromoPrice,
                Description = entity.QuantityPromotion.Description,
            };
        }
    }
}
