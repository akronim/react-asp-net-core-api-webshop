using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebShopApiCore.Models
{
    [Table("OrderItem")]
    public class OrderItem
    {
        [Required]
        public Int32 OrderItemID { get; set; }

        [Required]
        public Int32 OrderID { get; set; }

        [Required]
        public Int32 ItemID { get; set; }

        [Required]
        public Int32 Quantity { get; set; }

        public virtual Order Order { get; set; }

        public virtual Item Item { get; set; }
    }
}
