using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebShopApiCore.Models
{
    [Table("FinalCostPromotion")]
    public class FinalCostPromotion
    {
        [Required]
        public Int32 FinalCostPromotionID { get; set; }

        [Column(TypeName = "decimal(4,2)")]
        public Decimal PercentageValue { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public Decimal AbsoluteValue { get; set; }

        [Required]
        public Boolean Cumulative { get; set; }

        [MaxLength(250)]
        public String Description { get; set; }

        public virtual ICollection<OrderFinalCostPromotion> OrderFinalCostPromotions { get; set; }
    }
}
