using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebShopApiCore.Models
{
    [Table("Item")]
    public class Item
    {
        [Required]
        public Int32 ItemID { get; set; }

        [Required]
        [MaxLength(150)]
        public String Name { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public Decimal Price { get; set; }

        public virtual ICollection<ItemQuantityPromotion> ItemQuantityPromotions { get; set; }

        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
