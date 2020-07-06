using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebShopApiCore.Models
{
    [Table("ItemQuantityPromotion")]
    public class ItemQuantityPromotion
    {
        [Required]
        public Int32 ItemQuantityPromotionID { get; set; }

        [Required]
        public Int32 ItemID { get; set; }

        [Required]
        public Int32 QuantityPromotionID { get; set; }

        public virtual Item Item { get; set; }

        public virtual QuantityPromotion QuantityPromotion { get; set; }
    }
}
