using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebShopApiCore.Models
{
    [Table("Order")]
    public class Order
    {
        [Required]
        public Int32 OrderID { get; set; }

        [Required]
        public Int32 CustomerID { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal TotalPrice { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual ICollection<OrderFinalCostPromotion> OrderFinalCostPromotions { get; set; }

        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
