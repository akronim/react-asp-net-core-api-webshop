using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShopApiCore.Models;

namespace WebShopApiCore.DTO
{
    public class ItemDTO
    {
        public Int32 ItemID { get; set; }

        public String Name { get; set; }

        public Decimal Price { get; set; }


        public static ItemDTO FromEntity(Item entity)
        {
            return new ItemDTO
            {
                ItemID = entity.ItemID,
                Name = entity.Name,
                Price = entity.Price
            };
        }

        public void ToEntity(Item entity)
        {
            entity.ItemID = ItemID;
            entity.Name = Name;
            entity.Price = Price;
        }
    }
}
