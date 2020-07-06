using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebShopApiCore.Models
{
    [Table("OrderFinalCostPromotion")]
    public class OrderFinalCostPromotion
    {
        [Required]
        public Int32 OrderFinalCostPromotionID { get; set; }

        [Required]
        public Int32 OrderID { get; set; }

        [Required]
        public Int32 FinalCostPromotionID { get; set; }

        public virtual Order Order { get; set; }

        public virtual FinalCostPromotion FinalCostPromotion { get; set; }
    }
}
