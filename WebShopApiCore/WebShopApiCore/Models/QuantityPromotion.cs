using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebShopApiCore.Models
{
    [Table("QuantityPromotion")]
    public class QuantityPromotion
    {
        [Required]
        public Int32 QuantityPromotionID { get; set; }

        [Required]
        public Int32 PromoQuantity { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public Decimal PromoPrice { get; set; }

        [MaxLength(250)]
        public String Description { get; set; }

        public virtual ICollection<ItemQuantityPromotion> ItemQuantityPromotions { get; set; }
    }
}
