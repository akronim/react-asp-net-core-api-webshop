using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebShopApiCore.Models
{
    [Table("Customer")]
    public class Customer
    {
        [Required]
        public Int32 CustomerID { get; set; }

        [Required]
        [MaxLength(250)]
        public String Email { get; set; }

        [Required]
        [MaxLength(250)]
        public String Address { get; set; }

        [Required]
        [MaxLength(250)]
        public String CreditCard { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
